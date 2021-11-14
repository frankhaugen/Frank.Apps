namespace Frank.Apps.StarMap.Models;

public class Star
{
    public int Id { get; set; }
    public int? Hip { get; set; }
    public int? Hd { get; set; }
    public int? Hr { get; set; }
    public string Gl { get; set; }
    public string Bf { get; set; }
    public string Proper { get; set; }
    public double Ra { get; set; }
    public double Dec { get; set; }
    public double Dist { get; set; }
    public double Pmra { get; set; }
    public double Pmdec { get; set; }
    public double Rv { get; set; }
    public string Mag { get; set; }
    public double Absmag { get; set; }
    public string Spect { get; set; }
    public string Ci { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public double Vx { get; set; }
    public double Vy { get; set; }
    public double Vz { get; set; }
    public double Rarad { get; set; }
    public double Decrad { get; set; }
    public double Pmrarad { get; set; }
    public double Pmdecrad { get; set; }
    public string Bayer { get; set; }
    public int? Flam { get; set; }
    public string Con { get; set; }
    public int Comp { get; set; }
    public int CompPrimary { get; set; }
    public string Base { get; set; }
    public double Lum { get; set; }
    public string Var { get; set; }
    public string VarMin { get; set; }
    public string VarMax { get; set; }
}