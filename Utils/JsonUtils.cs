using System.Text.RegularExpressions;
using System.Text.Json;

namespace Utils{
    public static class JsonUtils{
        public static bool TryFormatJson(string input, out string formatted, out string error){
            formatted = "";
            error = "";
            try{
                // 項目名のダブルクォーテーション補正
                string corrected = Regex.Replace(input, @"(?<={|,)\s*(\w+)\s*:", "\"$1\":");

                // System.Text.Jsonでパース＆整形
                using JsonDocument doc = JsonDocument.Parse(corrected);
                formatted = JsonSerializer.Serialize(doc.RootElement, new JsonSerializerOptions { WriteIndented = true });
                return true;
            } catch (JsonException ex) {
                error = ex.Message;
                return false;
            }
        }
    }
}
