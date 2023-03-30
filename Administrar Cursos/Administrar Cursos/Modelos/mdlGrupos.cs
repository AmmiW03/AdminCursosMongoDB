using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrar_Cursos.Modelos
{
    public class mdlGrupos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String sId { get; set; }
        [BsonElement]
        public String sNombre { get; set; }
        [BsonElement]
        public List<mdlUsuario> lstUsuarios = new List<mdlUsuario>();

    }
}
