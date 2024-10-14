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
        /*
        writer = new StreamWriter("Verts and Matrices.txt");
        myLetter = new Model();
        myLetter.CreateUnityGameObject();
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

        writer.WriteLine("" +
            "" +
            "" +
            "" +
            "");
        Matrix4x4 scaleMatrix =
         Matrix4x4.TRS(Vector3.zero,
                     Quaternion.identity,
                     new Vector3(7, 3, 5));

        writeMatrixToFile(scaleMatrix);

        List<Vector4> imageAfterScale =
    applyTransformation(imageAfterRotation, scaleMatrix);




        writer.WriteLine("Verts");

        writeVertsToFile(imageAfterScale);

        writer.WriteLine("" +
            "" +
            "" +
            "" +
            "");
        Matrix4x4 translationMatrix =
         Matrix4x4.TRS(new Vector3(4, 2, -4),
                     Quaternion.identity,
                     Vector3.one);

        writeMatrixToFile(translationMatrix);

        List<Vector4> imageAfterTranslation =
    applyTransformation(imageAfterScale, translationMatrix);




        writer.WriteLine("Verts");

        writeVertsToFile(imageAfterTranslation);

        writer.WriteLine("" +
            "" +
            "" +
            "" +
            "");

        Matrix4x4 transformationMatrix = translationMatrix * scaleMatrix * rotationMatrix;
        writeMatrixToFile(transformationMatrix);

        List<Vector4> imageAfterTransformation =
    applyTransformation(verts, transformationMatrix);

        writer.WriteLine("Verts");

        writeVertsToFile(imageAfterTransformation);

        writer.WriteLine("" +
            "" +
            "" +
            "" +
            "");
        Matrix4x4 viewingMatrix = Matrix4x4.LookAt(new Vector3(20, -2, 45),
                     new Vector3(-5, 7, 5),
                     new Vector3(-4, -5, 18));

        writeMatrixToFile(viewingMatrix);

        List<Vector4> imageAfterViewing =
    applyTransformation(imageAfterTransformation, viewingMatrix);

        writer.WriteLine("Verts");

        writeVertsToFile(imageAfterViewing);



        writer.WriteLine("" +
             "" +
             "" +
             "" +
             "");
        Matrix4x4 projectionMatrix = Matrix4x4.Perspective(90, 1, 1, 1000);

        writeMatrixToFile(projectionMatrix);

        List<Vector4> imageAfterProjection =
    applyTransformation(imageAfterViewing, projectionMatrix);

        writer.WriteLine("Verts");

        writeVertsToFile(imageAfterProjection);



        writer.WriteLine("" +
            "" +
            "" +
            "" +
            "");
        Matrix4x4 singleMatrix = projectionMatrix * viewingMatrix * transformationMatrix;

        writeMatrixToFile(singleMatrix);

        List<Vector4> imageAfterSingle =
    applyTransformation(verts, singleMatrix);

        writer.WriteLine("Verts");

        writeVertsToFile(imageAfterSingle);



        
        writer.WriteLine("" +
            "" +
            "" +
            "" +
            "");
        Matrix4x4 handProjection = projectionMatrix * viewingMatrix * transformationMatrix;

        writeMatrixToFile(handProjection);

        List<Vector4> imageAfterHand =
    applyTransformation(imageAfterViewing, handProjection);

        writer.WriteLine("Verts");

        writeVertsToFile(imageAfterHand);
        writer.Close();
        */
        Outcode oone = new Outcode(new Vector2(-2, -2));
        Outcode otwo = new Outcode(new Vector2(2, 0));
        oone.displayOutcode();
        otwo.displayOutcode();
        (oone + otwo).displayOutcode();
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
