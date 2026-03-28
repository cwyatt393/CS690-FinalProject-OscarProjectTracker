using System.Text.Json;

namespace OscarProjectTracker;

public static class DataStore
{
    private const string FileName = "data.json";

    public static void Save(List<Hobby> hobbies)
    {
        var json = JsonSerializer.Serialize(hobbies,
            new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileName, json);
    }

    public static List<Hobby> Load()
    {
        if (!File.Exists(FileName))
            return new List<Hobby>();

        var json = File.ReadAllText(FileName);
        return JsonSerializer.Deserialize<List<Hobby>>(json)
               ?? new List<Hobby>();
    }
}