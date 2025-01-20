

public class Visa
{
    public int Num { get; set; }
    public int ThreeDig { get; set; } 
    public string Date { get; set; }

    public Visa(int num, int threeDig, string date)
    {
        this.Num = num;
        this.ThreeDig = threeDig;
        this.Date = date;
    }
}
