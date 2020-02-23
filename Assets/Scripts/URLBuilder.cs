using System;
using System.Collections.Generic;
public class URIBuilder
{
    private static string _url;
    private static List<string> _parameters = new List<string>();

    public URIBuilder(string url)
    {
        _url = url;
    }

    public string GetURI()
    {
        if (_parameters.Count == 0)
            return _url;

        string returnURI = _url + _parameters[0];

        for (int i = 1; i < _parameters.Count; i++)
        {
            returnURI += ("&" + _parameters[i]);
        }

        return returnURI;
    }

    public void SetParameter(string parametrName, object parametrValue) {
        try
        {
            int changeIndex = _parameters.FindIndex(x => x.Contains(parametrName));
            _parameters[changeIndex] = parametrName + "=" + parametrValue;
        }
        catch (Exception e)
        {
            _parameters.Add(parametrName + "=" + parametrValue);
        }
    }

    public void RemoveParameter(string parametrName)
    {
        try { 
            int removeIndex = _parameters.FindIndex(x => x.Contains(parametrName));
            _parameters.RemoveAt(removeIndex);
        }
        catch (Exception e)
        {
        }
    }
}