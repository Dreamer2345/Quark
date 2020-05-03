using QuarkPhysicsEngine.Vec2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkPhysicsEngine.Primatives
{
    public class VertexArray
    {
        const int MaxNumberOfVerts = 64;


        int NumberOfVertexes = 3;
        vector2[] Vertices;
        vector2[] VertNormals;

        public VertexArray(List<vector2> Vertices, List<vector2> Normals)
        {
            if (Vertices.Count != Normals.Count)
                throw new Exception("Vertex count not equal to Normal count");
            if(Vertices.Count < 3)
                throw new Exception("Vertex count cannot be less than three for polygon");


            this.Vertices = new vector2[Vertices.Count];
            VertNormals = new vector2[Vertices.Count];

            Vertices.CopyTo(VertNormals);
            Normals.CopyTo(VertNormals);
        }
    }
}
