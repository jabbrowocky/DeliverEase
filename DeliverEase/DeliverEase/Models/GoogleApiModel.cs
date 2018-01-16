using DeliverEase.Models;
using System;
using System.Net;
using System.Collections.Generic;
using DeliverEase;
using Newtonsoft.Json;
using RestSharp;

public partial class GoogleApi
{
    [JsonProperty("results")]
    public Result[] Results { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }
    
}

public partial class Result
{
    [JsonProperty("address_components")]
    public AddressComponent[] AddressComponents { get; set; }

    [JsonProperty("formatted_address")]
    public string FormattedAddress { get; set; }

    [JsonProperty("geometry")]
    public Geometry Geometry { get; set; }

    [JsonProperty("place_id")]
    public string PlaceId { get; set; }

    [JsonProperty("types")]
    public string[] Types { get; set; }
}

public partial class AddressComponent
{
    [JsonProperty("long_name")]
    public string LongName { get; set; }

    [JsonProperty("short_name")]
    public string ShortName { get; set; }

    [JsonProperty("types")]
    public string[] Types { get; set; }
}

public partial class Geometry
{
    [JsonProperty("bounds")]
    public Bounds Bounds { get; set; }

    [JsonProperty("location")]
    public Northeast Location { get; set; }

    [JsonProperty("location_type")]
    public string LocationType { get; set; }

    [JsonProperty("viewport")]
    public Bounds Viewport { get; set; }
}

public partial class Bounds
{
    [JsonProperty("northeast")]
    public Northeast Northeast { get; set; }

    [JsonProperty("southwest")]
    public Northeast Southwest { get; set; }
}

public partial class Northeast
{
    [JsonProperty("lat")]
    public double Lat { get; set; }

    [JsonProperty("lng")]
    public double Lng { get; set; }
}

public partial class GoogleApi
{
    public static GoogleApi FromJson(string json) => JsonConvert.DeserializeObject<GoogleApi>(json, Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this GoogleApi self) => JsonConvert.SerializeObject(self, Converter.Settings);
}

public class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
    };
}

