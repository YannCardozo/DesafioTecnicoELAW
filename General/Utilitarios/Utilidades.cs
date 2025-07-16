using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace General.Utilitarios
{
    public class Utilidades
    {
        public class SNBoolConverter : JsonConverter<bool>
        {
            public override bool Read(ref Utf8JsonReader reader, Type t, JsonSerializerOptions o)
                => reader.GetString() == "S";
            public override void Write(Utf8JsonWriter w, bool value, JsonSerializerOptions o) =>
                w.WriteStringValue(value ? "S" : "N");
        }
    }
}
