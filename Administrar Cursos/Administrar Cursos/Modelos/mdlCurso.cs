using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrar_Cursos.Modelos
{
    public class mdlCurso
    {
        [BsonElement]
        public String sNombre { get; set; }
        [BsonElement]
        public String sFecha { get; set; }
    }
}
