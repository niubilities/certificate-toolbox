using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Math;

namespace CertificateToolbox;

public partial class CertificateDetails : UserControl
{
    private readonly BigInteger _serialNo;

    public CertificateDetails()
    {
        InitializeComponent();
    }

    public CertificateDetails(BigInteger serialNumber, CertificateDetails? issuer)
    {
        InitializeComponent();

        Issuer = issuer;

        _serialNo = serialNumber;
        serial.Text = serialNumber.ToString();
        subject.Text = $@"CN={Environment.MachineName} {serialNumber}";

        store_name.DataSource = Enum.GetValues(typeof(StoreName));
        store_name.SelectedItem = StoreName.Root;

        store_location.DataSource = Enum.GetValues(typeof(StoreLocation));
        store_location.SelectedItem = StoreLocation.LocalMachine;

        not_before.Value = DateTime.UtcNow.AddDays(-1);
        not_after.Value = DateTime.UtcNow.AddYears(100);

        subject_alternative_names.ReadOnly = is_ca.Checked;
        key_usages.ReadOnly = is_ca.Checked;
        subject_alternative_names.Visible = !is_ca.Checked;
        key_usages.Visible = !is_ca.Checked;
        ocsp.Add();
        ocsp.GetResponse = GetOcsp;

        crl.Add();
        crl.GetResponse = GetCrl;
    }

    public X509Certificate2? Certificate { get; set; }
    public CertificateDetails? Issuer { get; set; }
    public X509Certificate2? OcspResponder { get; set; }

    public event Action<CertificateDetails> RemoveRequested;

    public X509Certificate2? Generate()
    {
        StopRevocationServers();

        RemoveExistingCertificate();

        ClearThumbprint();

        GenerateCertificate();

        if (install_store.Checked) InstallNewCertificate();

        UpdateThumbprint();

        if (has_ocsp_responder.Checked) GenerateOcspResponder();

        StartRevocationServers();

        return Certificate;
    }

    public void RemoveExistingCertificate()
    {
        if (string.IsNullOrEmpty(thumbprint.Text)) return;

        foreach (var storeLocation in new[] { StoreLocation.LocalMachine, StoreLocation.CurrentUser })
        foreach (StoreName storeName in Enum.GetValues(typeof(StoreName)))
        {
            var store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadWrite | OpenFlags.MaxAllowed);
            var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint.Text, false);
            if (certificates.Count == 1) store.Remove(certificates[0]);
            store.Close();
        }
    }

    private void ClearThumbprint()
    {
        thumbprint.Clear();
        Refresh();
    }

    private void copy_Click(object sender, EventArgs e)
    {
        Clipboard.SetText(thumbprint.Text);
    }

    private void GenerateCertificate()
    {
        var generator = new Generator
        {
            SerialNumber = new BigInteger(serial.Text),
            SubjectName = subject.Text,
            NotBefore = not_before.Value,
            NotAfter = not_after.Value,
            IsCertificateAuthority = is_ca.Checked,
            Issuer = GetIssuer(),
            SubjectAlternativeNames = Serialize(subject_alternative_names.Rows),
            Usages = Serialize(key_usages.Rows),
            OcspEndpoints = ocsp.Urls,
            CrlEndpoints = crl.Urls
        };

        Certificate = generator.Generate();
    }

    private void GenerateOcspResponder()
    {
        var generator = new Generator
        {
            SerialNumber = new BigInteger(serial.Text + "00"),
            SubjectName = subject.Text + "_OCSP_responder",
            NotBefore = not_before.Value,
            NotAfter = not_after.Value,
            Issuer = Issuer?.Certificate,
            Usages = new[] { "ocsp" },
            SubjectAlternativeNames = Array.Empty<string>(),
            OcspEndpoints = Array.Empty<string>(),
            CrlEndpoints = Array.Empty<string>()
        };

        OcspResponder = generator.Generate();
    }

    private byte[] GetCrl(RevocationStatus status)
    {
        var generator = new Generator
        {
            Issuer = Issuer == null ? Certificate : Issuer.Certificate,
            SerialNumber = _serialNo
        };

        return generator.GetCrl(status);
    }

    private X509Certificate2? GetIssuer()
    {
        return Issuer switch
        {
            null => null,
            _ => Issuer.is_recreate_required.Checked switch
            {
                true => Issuer.Generate(),
                _ => Issuer.Certificate
            }
        };
    }

    private byte[] GetOcsp(RevocationStatus status)
    {
        var generator2 = new Generator
        {
            Issuer = Issuer == null ? Certificate : Issuer.Certificate,
            SerialNumber = _serialNo
        };

        return generator2.GetOcspResponse(status, OcspResponder, include_ocsp_cert.Checked);
    }

    private void InstallNewCertificate()
    {
        var store = new X509Store((StoreName)store_name.SelectedItem, (StoreLocation)store_location.SelectedItem);
        store.Open(OpenFlags.ReadWrite);
        if (Certificate != null) store.Add(Certificate);
        store.Close();
    }

    private void is_ca_CheckedChanged(object sender, EventArgs e)
    {
        subject_alternative_names.ReadOnly = is_ca.Checked;
        key_usages.ReadOnly = is_ca.Checked;
        subject_alternative_names.Visible = !is_ca.Checked;
        key_usages.Visible = !is_ca.Checked;

        if (is_ca.Checked)
        {
            subject_alternative_names.Rows.Clear();

            key_usages.Rows.Clear();
        }
    }

    private void remove_Click(object sender, EventArgs e)
    {
        RemoveExistingCertificate();
        StopRevocationServers();
        RemoveRequested?.Invoke(this);
    }

    private string?[] Serialize(DataGridViewRowCollection rows)
    {
        return rows.Cast<DataGridViewRow>()
            .Where(row => row.Cells[0].Value != null)
            .Select(row => row.Cells[0].Value.ToString()).ToArray();
    }

    private void StartRevocationServers()
    {
        ocsp.Start();
        crl.Start();
    }

    private void StopRevocationServers()
    {
        ocsp.Stop();
        crl.Stop();
    }

    private void UpdateThumbprint()
    {
        thumbprint.Text = Certificate?.Thumbprint;
        Refresh();
    }
}