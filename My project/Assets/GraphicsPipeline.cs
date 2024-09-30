using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GraphicsPipeline : MonoBehaviour
{
    StreamWriter writer;
    Model myLetter;
    // Start is called before the first frame update
    void Start()
    {

        writer = new StreamWriter("Verts and Matrices.txt");
        myLetter = new Model();
        // myLetter.CreateUnityGameObject();
        List<Vector4> verts = convertToHomg(myLetter.vertices);


        writeVertsToFile(verts);

        Vector3 axis = (new Vector3(18, -5, -5)).normalized;
        Matrix4x4 rotationMatrix =
            Matrix4x4.TRS(Vector3.zero,
                        Quaternion.AngleAxis(29, axis),
                        Vector3.one);

        writeMatrixToFile(rotationMatrix);

        List<Vector4> imageAfterRotation =
    applyTransformation(verts, rotationMatrix);


        

        writer.WriteLine("Verts");

        writeVertsToFile(imageAfterRotation);

   
        writer.Close();
    }

    private void writeVertsToFile(List<Vector4> listOfVerts)
    {
        foreach (Vector4 vert in listOfVerts)
        {
            writer.WriteLine(vert);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<Vector4> applyTransformation
    (List<Vector4> verts, Matrix4x4 tranformMatrix)
    {
        List<Vector4> output = new List<Vector4>();
        foreach (Vector4 v in verts)
        { output.Add(tranformMatrix * v); }

        return output;

    }
    private List<Vector4> convertToHomg(List<Vector3> vertices)
    {
        List<Vector4> output = new List<Vector4>();

        foreach (Vector3 v in vertices)
        {
            output.Add(new Vector4(v.x, v.y, v.z, 1.0f));

        }
        return output;

    }

    private void writeMatrixToFile(Matrix4x4 matrix)
    {
        for (int i = 0; i < 4; i++)
            writer.WriteLine(matrix.GetRow(i).x + " , " + matrix.GetRow(i).y + " , " + matrix.GetRow(i).z + " , " + matrix.GetRow(i).w);
    }

    


}
