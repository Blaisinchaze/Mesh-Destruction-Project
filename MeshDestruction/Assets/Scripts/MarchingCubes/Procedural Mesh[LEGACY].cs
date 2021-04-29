
//using UnityEngine;

//public class ProceduralMesh : MonoBehaviour
//{
//    public Vector3 GridSize;
//    public Material material;
//    private Mesh mesh;

//    private void Start()
//    {
//        MakeGrid();
//        Noise2D();
//        March();
//    }

//    private void MakeGrid()
//    {
//        //allocate
//        MarchingCube.grd = new GridPoint[(int)GridSize.x, (int)GridSize.y, (int)GridSize.z];

//        //define the points
//        for (int x = 0; x < GridSize.x; x++)
//        {
//            for (int y = 0; y < GridSize.y; y++)
//            {
//                for (int z = 0; z < GridSize.z; z++)
//                {
//                    MarchingCube.grd[x, y, z] = new GridPoint();
//                    MarchingCube.grd[x, y, z].Position = new Vector3(x, y, z);
//                    MarchingCube.grd[x, y, z].On = false;
//                }

//            }

//        }
//    }
//    private void Noise2D()
//    {
//        //define the points
//        for (int x = 0; x < GridSize.x; x++)
//        {
//            for (int z = 0; z < GridSize.z; z++)
//            {
//                float nx = (x / GridSize.x);
//                float nz = (z / GridSize.z);
//                float height = Mathf.PerlinNoise(nx, nz);

//                for (int y = 0; y < GridSize.y; y++)
//                {
//                    MarchingCube.grd[x, y, x].On = (y < height);
//                }
//            }
//        }
//    }
//    private void March()
//    {
//        GameObject go = this.gameObject;
//        mesh = MarchingCube.GetMesh(ref go, ref material);
        
//        MarchingCube.Clear();
//        MarchingCube.MarchCubes();

//        MarchingCube.SetMesh(ref mesh);
    
//    }
//}
