namespace PrefectPay;

public partial class MainPage : ContentPage
{
    short personsCount = 0;
    double tip = 0;
    double bill = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void btnDecreaseCount_Clicked(object sender, EventArgs e)
    {
        if (personsCount <= 0) return;
        personsCount -= 1;
        lblCount.Text = personsCount.ToString();
        if (bill > 0 && personsCount > 0)
            lblTotal.Text = "$" + (Math.Truncate(100 * ((bill + priceOfTip(tip)) / personsCount)) / 100).ToString();
    }

    private void btnIncreaseCount_Clicked(object sender, EventArgs e)
    {
        if (personsCount < 0) return;
        personsCount += 1;
        lblCount.Text = personsCount.ToString();
        if (bill > 0 && personsCount > 0)
            lblTotal.Text = "$" + (Math.Truncate(100 * ((bill + priceOfTip(tip)) / personsCount)) / 100).ToString();
    }

    private void btn10PrecentTip_Clicked(object sender, EventArgs e)
    {
        tip = 0.1;
        setTip();
    }

    private void btn15PrecentTip_Clicked(object sender, EventArgs e)
    {
        tip = 0.15;
        setTip();

    }

    private void btn20PrecentTip_Clicked(object sender, EventArgs e)
    {
        tip = 0.2;
        setTip();
    }

    private void etnryBill_Completed(object sender, EventArgs e)
    {
        bool isCorrect = double.TryParse(etnryBill.Text, out double result);
        if (isCorrect) bill = result;
        else bill = 0.0;
        lblSubTotal.Text = "$" + bill.ToString();
        setTip();
    }

    private void sliderTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = Math.Truncate(100 * sliderTip.Value) / 100;
        setTip();
    }
    private void setTip()
    {
        lblTip.Text = "Tip : " + fixTip(tip).ToString() + "%";
        sliderTip.Value = tip;
        if (bill > 0)
        {
            lblTotalTip.Text = "$" + priceOfTip(tip).ToString();
            if (personsCount > 0)
                lblTotal.Text = "$" + (Math.Truncate(100 * ((bill + priceOfTip(tip)) / personsCount)) / 100).ToString();
        }
    }
    private double fixTip(double tip)
    {
        return Math.Round(tip * 100);
    }
    private double priceOfTip(double tip)
    {
        return (Math.Truncate(100 * (tip * bill)) / 100);
    }

}

