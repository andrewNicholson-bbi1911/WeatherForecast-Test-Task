public partial class ForecastInfo
{
    public int now { get; set; }
    public System.DateTime now_dt { get; set; }
    public Info info { get; set; }
    public Fact fact { get; set; }
    public System.Collections.Generic.List<Forecast> forecasts { get; set; }
}

public class Tzinfo
{
    public string name { get; set; }
    public string abbr { get; set; }
    public int offset { get; set; }
    public bool dst { get; set; }
}

public class Info
{
    public bool f { get; set; }
    public bool n { get; set; }
    public bool nr { get; set; }
    public bool ns { get; set; }
    public bool nsr { get; set; }
    public bool p { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public int geoid { get; set; }
    public string slug { get; set; }
    public int zoom { get; set; }
    public Tzinfo tzinfo { get; set; }
    public int def_pressure_mm { get; set; }
    public int def_pressure_pa { get; set; }
    public bool _h { get; set; }
    public string url { get; set; }
}

public class AccumPrec
{
    public double __invalid_name__1 { get; set; }
    public double __invalid_name__3 { get; set; }
    public double __invalid_name__7 { get; set; }
}

public class Fact
{
    public int temp { get; set; }
    public int feels_like { get; set; }
    public int temp_water { get; set; }
    public string icon { get; set; }
    public string condition { get; set; }
    public double wind_speed { get; set; }
    public double wind_gust { get; set; }
    public string wind_dir { get; set; }
    public int pressure_mm { get; set; }
    public int pressure_pa { get; set; }
    public int humidity { get; set; }
    public int uv_index { get; set; }
    public int soil_temp { get; set; }
    public double soil_moisture { get; set; }
    public string daytime { get; set; }
    public bool polar { get; set; }
    public string season { get; set; }
    public int obs_time { get; set; }
    public AccumPrec accum_prec { get; set; }
    public string source { get; set; }
}

public class Day
{
    public string _source { get; set; }
    public int temp_min { get; set; }
    public int temp_max { get; set; }
    public int temp_avg { get; set; }
    public int feels_like { get; set; }
    public int temp_water { get; set; }
    public string icon { get; set; }
    public string condition { get; set; }
    public string daytime { get; set; }
    public bool polar { get; set; }
    public double wind_speed { get; set; }
    public double wind_gust { get; set; }
    public string wind_dir { get; set; }
    public int pressure_mm { get; set; }
    public int pressure_pa { get; set; }
    public int humidity { get; set; }
    public int uv_index { get; set; }
    public int soil_temp { get; set; }
    public double soil_moisture { get; set; }
    public double prec_mm { get; set; }
    public int prec_period { get; set; }
    public int prec_prob { get; set; }
}

public class Parts
{
    public Day night { get; set; }
    public Day morning { get; set; }
    public Day day { get; set; }
    public Day evening { get; set; }
    public Day day_short { get; set; }
    public Day night_short { get; set; }
}

public class Forecast
{
    public string date { get; set; }
    public int date_ts { get; set; }
    public int week { get; set; }
    public string sunrise { get; set; }
    public string sunset { get; set; }
    public string rise_begin { get; set; }
    public string set_end { get; set; }
    public int moon_code { get; set; }
    public string moon_text { get; set; }
    public Parts parts { get; set; }
}



