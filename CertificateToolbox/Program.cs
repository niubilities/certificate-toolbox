﻿namespace CertificateToolbox;

internal static class Program
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Application.ThreadException += Application_ThreadException;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Shell());
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
    }
}