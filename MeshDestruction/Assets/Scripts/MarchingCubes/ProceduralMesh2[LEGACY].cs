//using UnityEngine;

//public class ProceduralMesh2 : MonoBehaviour
//{
//    public Vector3 GridSize = new Vector3(10, 5, 10);
//    public Material material = null;
//    public float pointyness;
//    public float noiselimit = 0.5f;
//    public bool threeDeeMesh;
//    private Mesh mesh = null;
//    private bool bUpdateRequest = false;

//    private void Start()
//    {
//        MakeGrid();
//        if (threeDeeMesh)
//            Noise3D();
//        else
//            Noise2D();
//        March();
//    }

//    private void Update()
//    {
//        if (bUpdateRequest)
//        {
//            March();
//            bUpdateRequest = false;
//        }
//    }

//    private void MakeGrid()
//    {
//        //allocate
//        MarchingCube.grd = new GridPoint[(int)GridSize.x, (int)GridSize.y, (int)GridSize.z];

//        //define the points
//        for (int z = 0; z < GridSize.z; z++)
//        {
//            for (int y = 0; y < GridSize.y; y++)
//            {
//                for (int x = 0; x < GridSize.x; x++)
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
//        for (int z = 0; z < GridSize.z; z++)
//        {
//            for (int x = 0; x < GridSize.x; x++)
//            {
//                float nx = (x / GridSize.x) * pointyness;
//                float nz = (z / GridSize.z) * pointyness;
//                float height = Mathf.PerlinNoise(nx, nz) * GridSize.y;

//                for (int y = 0; y < GridSize.y; y++)
//                {
//                    MarchingCube.grd[x, y, z].On = (y < height);
//                }
//            }
//        }
//    }
//    private void Noise3D()
//    {
//        for (int z = 0; z < GridSize.z; z++)
//        {
//            for (int y = 0; y < GridSize.y; y++)
//            {
//                for (int x = 0; x < GridSize.x; x++)
//                {
//                    float nx = (x / GridSize.x) * pointyness;
//                    float ny = (y / GridSize.y) * pointyness;
//                    float nz = (z / GridSize.z) * pointyness;
//                    float noise = MarchingCube.PerlinNoise3D(nx, ny, nz);
                    
//                    MarchingCube.grd[x, y, z].On = (noise > noiselimit);

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
