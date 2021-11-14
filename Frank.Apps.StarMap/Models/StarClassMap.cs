using CsvHelper.Configuration;

namespace Frank.Apps.StarMap.Models;

public class StarClassMap : ClassMap<Star>
{
    public StarClassMap()
    {
        Map(m => m.Id).Name("id").Ignore(true);
        Map(m => m.Hip).Name("hip");
        Map(m => m.Hd).Name("hd");
        Map(m => m.Hr).Name("hr");
        Map(m => m.Gl).Name("gl");
        Map(m => m.Bf).Name("bf");
        Map(m => m.Proper).Name("proper");
        Map(m => m.Ra).Name("ra");
        Map(m => m.Dec).Name("dec");
        Map(m => m.Dist).Name("dist");
        Map(m => m.Pmra).Name("pmra");
        Map(m => m.Pmdec).Name("pmdec");
        Map(m => m.Rv).Name("rv");
        Map(m => m.Mag).Name("mag");
        Map(m => m.Absmag).Name("absmag");
        Map(m => m.Spect).Name("spect");
        Map(m => m.Ci).Name("ci");
        Map(m => m.X).Name("x");
        Map(m => m.Y).Name("y");
        Map(m => m.Z).Name("z");
        Map(m => m.Vx).Name("vx");
        Map(m => m.Vy).Name("vy");
        Map(m => m.Vz).Name("vz");
        Map(m => m.Rarad).Name("rarad");
        Map(m => m.Decrad).Name("decrad");
        Map(m => m.Pmrarad).Name("pmrarad");
        Map(m => m.Pmdecrad).Name("pmdecrad");
        Map(m => m.Bayer).Name("bayer");
        Map(m => m.Flam).Name("flam");
        Map(m => m.Con).Name("con");
        Map(m => m.Comp).Name("comp");
        Map(m => m.CompPrimary).Name("comp_primary");
        Map(m => m.Base).Name("base");
        Map(m => m.Lum).Name("lum");
        Map(m => m.Var).Name("var");
        Map(m => m.VarMin).Name("var_min");
        Map(m => m.VarMax).Name("var_max");
    }
}