using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GraphicsPipeline : MonoBehaviour
{
    Model myModel = new Model();
    StreamWriter writer;
    Model myLetter;
    Texture2D screenTexture;
    Renderer ScreenRender;
    private int angle;
    Vector2 a2, b2, c2, A, B;
    private Vector2 a_t;
    private Vector2 b_t;
    private Vector2 c_t;
    public Texture2D texturefile;
     Vector2 A_t;
     Vector2 B_t;

    // Start is called before the first frame update
    void Start()
    {
        screenTexture = new Texture2D(1024, 1024);

        GameObject ScreenGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ScreenRender = ScreenGO.GetComponent<Renderer>();
        ScreenGO.transform.up = Vector3.back;
        
        ScreenRender.material.mainTexture = screenTexture;

        List<Vector2Int> points = bresh(new Vector2Int(0, 0), new Vector2Int(1024, 1024));
        foreach (Vector2Int point in points)
            screenTexture.SetPixel(point.x, point.y, UnityEngine.Color.red);
        screenTexture.Apply();



        /*writer = new StreamWriter("Verts and Matrices.txt");
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
        Outcode oone = new Outcode(new Vector2(-2, -2));
        Outcode otwo = new Outcode(new Vector2(2, 0));
        oone.displayOutcode();
        otwo.displayOutcode();
        (oone + otwo).displayOutcode();


        print(Intersect(new Vector2(-1.5f, 0.5f), new Vector2(0.5f, -1.5f), 0));

        
        */
    }
    private void DrawScanLines(EdgeTable edgeTable)
    {
        foreach(var item in edgeTable.edgeTable)
        {
            int y = item.Key;
            int xMin = item.Value.start;
            int xMax = item.Value.end;

            for(int x = xMin; x <= xMax; x++)
            {
                UnityEngine.Color col = GetColorFromTexture(x, y);
                screenTexture.SetPixel(x, y, col);
            }
        }

    }

    private UnityEngine.Color GetColorFromTexture(int x_p, int y_p)
    {
        float x = x_p - a2.x;
        float y = y_p - a2.y;
        float r = (((x) * (B.y)) - ((y) * (B.x))) / (((A.x) * (B.y)) - ((A.y) * (B.x)));
        float s = (((y) * (A.x)) - ((x) * (A.y))) / (((A.x) * (B.y)) - ((A.y) * (B.x)));
        Vector2 texturepoint = a_t + r*A_t + s*B_t;
        texturepoint *= 1024;
        return texturefile.GetPixel((int)texturepoint.x, (int)texturepoint.y);
    }

    private void process(Vector4 start4d, Vector4 end4d, EdgeTable edgeTable)
    {
        Vector2 start = project(start4d);
        Vector2 end = project(end4d);

        if (LineClip(ref start, ref end)){
           
            Vector2Int startPix = pixelize(start);
            Vector2Int endPix = pixelize(end);
            /*if ((startPix.x < 0) || (startPix.y < 0) || (endPix.x < 0) || (endPix.y < 0))
                print("jlhh");*/
            List<Vector2Int> points = bresh(startPix, endPix);
            //setPixels(points);
            edgeTable.Add(points);
            
                
        }
        
    }
    Vector2Int pixelize(Vector2 point) {
        return new Vector2Int((int)(Mathf.Round((point.x + 1) * 1023 / 2)), (int)(Mathf.Round((point.y + 1) * 1023 / 2)));
    }

    Vector2 project(Vector4 point)
    {
        return new Vector2(point.x/point.z , point.y/point.z);
    }

    void setPixels(List<Vector2Int> points)
    {
        foreach (Vector2Int v in points)
            screenTexture.SetPixel(v.x, v.y, UnityEngine.Color.red);
    }
    /// <summary>
    /// Use Cohen Sutherland Algorithm to clip the Line segment from start to end, NOTE start and end may change
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public bool LineClip(ref Vector2 start,ref Vector2 end)
    {
        Outcode startOutCode  = new Outcode(start);
        Outcode endOutCode = new Outcode(end);
        Outcode inScreenOutCode = new Outcode(Vector2.zero);   // 0000

        if ((startOutCode + endOutCode) == inScreenOutCode) return true;
        if ((startOutCode * endOutCode) != inScreenOutCode) return false;

        if (startOutCode == inScreenOutCode) return LineClip(ref end, ref start);

        // Start must be outside screen

        if (startOutCode.up)
        {
            start = Intersect(start, end, 0);
            return LineClip(ref start, ref end);
        }

        if (startOutCode.down)
        {
            start = Intersect(start, end, 1);
            return LineClip(ref start, ref end);
        }

        if (startOutCode.left)
        {
            start = Intersect(start, end, 2);
            return LineClip(ref start, ref end);
        }

        if (startOutCode.right)
        {
            start = Intersect(start, end, 3);
            return LineClip(ref start, ref end);
        }
        return false;
    }

    Vector2 Intersect(Vector2 start, Vector2 end, int edge)
    {
        float m, c;

        switch (edge)
        {
            case 0:
                if (end.x == start.x)
                    return new Vector2(end.x, 1);
                m = (end.y - start.y) / (end.x - start.x);
                c = start.y - m * (start.x);
                return new Vector2((1 - c) / m, 1);
            case 1:
                if (end.x == start.x)
                    return new Vector2(end.x, -1);
                m = (end.y - start.y) / (end.x - start.x);
                c = start.y - m * (start.x);
                return new Vector2((-1 - c) / m, -1);
            case 2:
                m = (end.y - start.y) / (end.x - start.x);
                c = start.y - m * (start.x);
                return new Vector2(-1, m * (-1) + c);
            default:
                m = (end.y - start.y) / (end.x - start.x);
                c = start.y - m * (start.x);
                return new Vector2(1, m * (1) + c);
        }
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
        Destroy(screenTexture);
        screenTexture = new Texture2D(1024, 1024);
        ScreenRender.material.mainTexture = screenTexture;
        angle +=1;
        Matrix4x4 M = Matrix4x4.TRS(new Vector3(0, 0, -10), Quaternion.AngleAxis(angle, Vector3.up), Vector3.one);
        List<Vector4> newVerts = applyTransformation(convertToHomg(myModel.vertices), M);
        for ( int i =0;i< myModel.faces.Count;i++)
        {
            Vector3Int face =myModel.faces[i];
            Vector3 a = newVerts[face.x]; //Vector3 a = newVerts[face.y] - newVerts[face.x];
            Vector3 b = newVerts[face.y]; //Vector3 b = newVerts[face.z] - newVerts[face.y];
            Vector3 c = newVerts[face.z];
            a2 = pixelize(project(a));
            b2 = pixelize(project(b));
            c2 = pixelize(project(c));
            A = b2 - a2;
            B = c2 - a2;

            a_t = myModel.texturecoordinates[myModel.texture_index_list[i].x];
            b_t = myModel.texturecoordinates[myModel.texture_index_list[i].y];
            c_t = myModel.texturecoordinates[myModel.texture_index_list[i].z];

            A_t = b_t - a_t;
            B_t = c_t - a_t;

            if (Vector3.Cross(b2-a2, c2-b2).z < 0)
            {
                EdgeTable edgeTable = new EdgeTable();
                process(newVerts[face.x], newVerts[face.y], edgeTable);
                process(newVerts[face.y], newVerts[face.z], edgeTable);
                process(newVerts[face.z], newVerts[face.x], edgeTable);

                DrawScanLines(edgeTable);
            }
        }

        screenTexture.Apply();
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


    List<Vector2Int> bresh(Vector2Int start, Vector2Int end) {
        List<Vector2Int> outList = new List<Vector2Int>();
        outList.Add(start);
        float xo = start.x;
        float yo = start.y;
        float xt = end.x;
        float yt = end.y;
        float dx = xt - xo;
        if (dx < 0) 
            return bresh(end, start);
        float dy = yt - yo;
        if (dy < 0)
            return  NegY(bresh(NegY(start), NegY(end)));
        if (dy > dx)
            return SwapXY(bresh(SwapXY(start), SwapXY(end)));
        float neg = 2*(dy - dx);
        float pos = 2 * dy;
        float p = 2 * dy - dx;
        while (xo < xt)
        {
            xo++;
            if (p < 0)
            {
                p += pos;
            }
            else
            {
                yo++;
                p += neg;
            }
            Vector2Int newPoint = new Vector2Int();
            newPoint.x = (int)xo;
            newPoint.y = (int)yo;
            outList.Add(newPoint);
            
        }
        return outList;
    }

    private List<Vector2Int> SwapXY(List<Vector2Int> vector2Ints)
    {
        List<Vector2Int> revs = new List<Vector2Int>();
        foreach (Vector2Int v in vector2Ints)
            revs.Add(SwapXY(v));
        return revs;
    }

    private Vector2Int SwapXY(Vector2Int point)
    {
        return new Vector2Int(point.y, point.x);
    }

    private List<Vector2Int> NegY(List<Vector2Int> vector2Ints)
    {
        List<Vector2Int> outputs = new List<Vector2Int>();
        foreach (Vector2Int v in vector2Ints)
            outputs.Add(NegY(v));
        return outputs;
    }

    private Vector2Int NegY(Vector2Int point)
    {
        return new Vector2Int(point.x, -point.y);
    }
}
