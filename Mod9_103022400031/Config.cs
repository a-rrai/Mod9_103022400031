using System;
using System.Collections.Generic;
using System.Text.Json;

public class Config
{
    public string lang { get; set; }    
    public int transfer { get; set; }
    public string[] methods { get; set; } 
    public string confirmation { get; set; }

    public Config() { }

    public Config(string lang, int transfer, string[] methods, string confirmation)
    {
        this.lang = lang;
        this.transfer = transfer;
        this.methods = methods;
        this.confirmation = confirmation;
    }
}
