using PrinterLibrary;
using SharedInterfaces;
namespace HW_T06_01_10_2026;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        this.FormClosing += (s, e) => Logger.Instance.Flush();
    }

    private void btnLogDebug_Click(object sender, EventArgs e)
    {
        Logger.Instance.LogData(LogLevel.Debug, "User clicked Debug button");
    }

    private void btnLogWarning_Click(object sender, EventArgs e)
    {
        Logger.Instance.LogData(LogLevel.Warning, "User clicked Warning button");
    }

    private void btnThreadLog_Click(object sender, EventArgs e)
    {
        Thread thread1 = new Thread(SetMessage);
        Thread thread2 = new Thread(SetMessage);

        thread1.Start(1);
        thread2.Start(2);
    }

    private void SetMessage(object? n)
    {
        Logger.Instance.LogData(LogLevel.Error, $"Message from thread #{n}");
    }

    private void buttonPrint_Click(object sender, EventArgs e)
    {
        string data = textBoxInputData.Text;

        if (string.IsNullOrWhiteSpace(data))
        {
            data = "Default document text";
        }

        var printerFactory = new PrinterFactory();
        IPrint printer = printerFactory.GetPrinter();
        printer.Print(data);

        Logger.Instance.LogData(LogLevel.Info, $"Printed document: {data}");
    }
}