using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model 
{
  public List<Vector3> vertices;
   List<Vector3Int> faces;
    List<Vector2> texturecoordinates;
    List<Vector3Int> texture_index_list;
    List<Vector3> normals;

   public Model()
    {
        vertices = new List<Vector3>();
        faces = new List<Vector3Int>();
        texturecoordinates = new List<Vector2>();
        texture_index_list = new List<Vector3Int>();   
        normals = new List<Vector3>();
        loadModelData();
    }

   private void loadModelData()
    {
        loadVertices();
        loadFaces();
    }

    private void loadVertices()
    {

        vertices.Add(new Vector3(-5, 5, 0)); //14
        vertices.Add(new Vector3(-5, 3, 0)); //15
        vertices.Add(new Vector3(5, 5, 0)); //16
        vertices.Add(new Vector3(5, 3, 0)); //17
        vertices.Add(new Vector3(-1, 3, 0)); //18
        vertices.Add(new Vector3(1, 3, 0)); //19
        vertices.Add(new Vector3(-1, -3, 0)); //20
        vertices.Add(new Vector3(1, -3, 0)); //21
        vertices.Add(new Vector3(-3, -3, 0)); //22
        vertices.Add(new Vector3(-5, -3, 0)); //23
        vertices.Add(new Vector3(-3, -1, 0)); //24
        vertices.Add(new Vector3(-5, -1, 0)); //25
        vertices.Add(new Vector3(-1, -5, 0)); //26
        vertices.Add(new Vector3(-3, -5, 0)); //27
        vertices.Add(new Vector3(-5, 5, 1)); //0 
        vertices.Add(new Vector3(-5, 3, 1)); //1
        vertices.Add(new Vector3(5, 5, 1)); //2
        vertices.Add(new Vector3(5, 3, 1)); //3
        vertices.Add(new Vector3(-1, 3, 1)); //4
        vertices.Add(new Vector3(1, 3, 1)); //5
        vertices.Add(new Vector3(-1, -3, 1)); //6
        vertices.Add(new Vector3(1, -3, 1)); //7
        vertices.Add(new Vector3(-3, -3, 1)); //8
        vertices.Add(new Vector3(-5, -3, 1)); //9
        vertices.Add(new Vector3(-3, -1, 1)); //10
        vertices.Add(new Vector3(-5, -1, 1)); //11
        vertices.Add(new Vector3(-1, -5, 1)); //12
        vertices.Add(new Vector3(-3, -5, 1)); //13
        
        texturecoordinates.Add(new Vector2((float)0.12988, (float)(1-0.12988))); //0
        texturecoordinates.Add(new Vector2((float)0.37891, (float)(1-0.12988))); //1
        texturecoordinates.Add(new Vector2((float)0.37891, (float)(1-0.19238))); //2
        texturecoordinates.Add(new Vector2((float)0.12988, (float)(1-0.19238))); //3
        texturecoordinates.Add(new Vector2((float)0.23633, (float)(1 - 0.19336))); //4
        texturecoordinates.Add(new Vector2((float)0.29883, (float)(1 - 0.19336))); //5
        texturecoordinates.Add(new Vector2((float)0.29883, (float)(1 - 0.36523))); //6
        texturecoordinates.Add(new Vector2((float)0.23633, (float)(1 - 0.36523))); //7
        texturecoordinates.Add(new Vector2((float)0.23633, (float)(1 - 0.42969))); //8
        texturecoordinates.Add(new Vector2((float)0.14648, (float)(1 - 0.36523))); //9
        texturecoordinates.Add(new Vector2((float)0.14648, (float)(1 - 0.42969))); //10
        texturecoordinates.Add(new Vector2((float)0.06543, (float)(1 - 0.37891))); //11
        texturecoordinates.Add(new Vector2((float)0.13770, (float)(1 - 0.32129))); //12
        texturecoordinates.Add(new Vector2((float)0.06543, (float)(1 - 0.32129))); //13
        texturecoordinates.Add(new Vector2((float)0.34961, (float)(1 - 0.46582))); //14
        texturecoordinates.Add(new Vector2((float)0.53223, (float)(1 - 0.46582))); //15
        texturecoordinates.Add(new Vector2((float)0.53223, (float)(1 - 0.54492))); //16
        texturecoordinates.Add(new Vector2((float)0.34961, (float)(1 - 0.54492))); //17
        texturecoordinates.Add(new Vector2((float)0.49609, (float)(1 - 0.14063))); //18
        texturecoordinates.Add(new Vector2((float)0.74512, (float)(1 - 0.14063))); //19
        texturecoordinates.Add(new Vector2((float)0.74512, (float)(1 - 0.20215))); //20
        texturecoordinates.Add(new Vector2((float)0.49609, (float)(1 - 0.20215))); //21
        texturecoordinates.Add(new Vector2((float)0.57617, (float)(1 - 0.20215))); //22
        texturecoordinates.Add(new Vector2((float)0.63965, (float)(1 - 0.20215))); //23
        texturecoordinates.Add(new Vector2((float)0.63965, (float)(1 - 0.37207))); //24
        texturecoordinates.Add(new Vector2((float)0.57617, (float)(1 - 0.37207))); //25
        texturecoordinates.Add(new Vector2((float)0.63086, (float)(1 - 0.43652))); //26
        texturecoordinates.Add(new Vector2((float)0.72852, (float)(1 - 0.37207))); //27
        texturecoordinates.Add(new Vector2((float)0.72852, (float)(1 - 0.43652))); //28
        texturecoordinates.Add(new Vector2((float)0.80957, (float)(1 - 0.3877))); //29
        texturecoordinates.Add(new Vector2((float)0.73535, (float)(1 - 0.33008))); //30
        texturecoordinates.Add(new Vector2((float)0.81152, (float)(1 - 0.3252))); //31



    }

    private void loadFaces()
    {
        faces.Add(new Vector3Int(0, 1, 3)); texture_index_list.Add(new Vector3Int(0, 3, 2)); normals.Add(new Vector3(0, 0, 1));//Front
        faces.Add(new Vector3Int(0, 3, 2)); texture_index_list.Add(new Vector3Int(0, 2, 1)); normals.Add(new Vector3(0, 0, 1));//Front
        faces.Add(new Vector3Int(4, 6, 7)); texture_index_list.Add(new Vector3Int(4, 7, 6)); normals.Add(new Vector3(0, 0, 1));//Front
        faces.Add(new Vector3Int(4, 7, 5)); texture_index_list.Add(new Vector3Int(4, 6, 5)); normals.Add(new Vector3(0, 0, 1));//Front
        faces.Add(new Vector3Int(6, 12, 7)); texture_index_list.Add(new Vector3Int(7, 8, 6)); normals.Add(new Vector3(0, 0, 1));//Front
        faces.Add(new Vector3Int(6, 8, 13)); texture_index_list.Add(new Vector3Int(7, 9, 10)); normals.Add(new Vector3(0, 0, 1));//Front
        faces.Add(new Vector3Int(6, 13, 12)); texture_index_list.Add(new Vector3Int(7, 10, 8)); normals.Add(new Vector3(0, 0, 1));//Front
        faces.Add(new Vector3Int(8, 9, 13)); texture_index_list.Add(new Vector3Int(9, 11, 10)); normals.Add(new Vector3(0, 0, 1));//Front
        faces.Add(new Vector3Int(8, 10, 11)); texture_index_list.Add(new Vector3Int(9, 12, 13)); normals.Add(new Vector3(0, 0, 1));//Front
        faces.Add(new Vector3Int(8, 11, 9)); texture_index_list.Add(new Vector3Int(9, 13, 11)); normals.Add(new Vector3(0, 0, 1));//Front
        faces.Add(new Vector3Int(9, 11, 25)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(1, 0, 0));//Sides
        faces.Add(new Vector3Int(9, 25, 23)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(1, 0, 0));//Sides
        faces.Add(new Vector3Int(4, 18, 20)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(1, 0, 0));//Sides
        faces.Add(new Vector3Int(4, 20, 6)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(1, 0, 0));//Sides
        faces.Add(new Vector3Int(14, 15, 1)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(1, 0, 0));//Sides
        faces.Add(new Vector3Int(14, 1, 0)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(1, 0, 0));//Sides
        faces.Add(new Vector3Int(9, 23, 27)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(1, 0, 0));//Sides
        faces.Add(new Vector3Int(9, 27, 13)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(1, 0, 0));//Sides
        faces.Add(new Vector3Int(10, 24, 25)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(0, 1, 0));//Top
        faces.Add(new Vector3Int(10, 25, 11)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(0, 1, 0));//Top
        faces.Add(new Vector3Int(6, 20, 22)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(0, 1, 0));//Top
        faces.Add(new Vector3Int(6, 22, 8)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(0, 1, 0));//Top
        faces.Add(new Vector3Int(2, 14, 0)); texture_index_list.Add(new Vector3Int(16, 14, 17)); normals.Add(new Vector3(0, 1, 0));//Top
        faces.Add(new Vector3Int(2, 16, 14)); texture_index_list.Add(new Vector3Int(16, 15, 14)); normals.Add(new Vector3(0, 1, 0));//Top
        faces.Add(new Vector3Int(14, 16, 17)); texture_index_list.Add(new Vector3Int(18, 19, 20)); normals.Add(new Vector3(0, 0, -1));//Back
        faces.Add(new Vector3Int(14, 17, 15)); texture_index_list.Add(new Vector3Int(18, 20, 21)); normals.Add(new Vector3(0, 0, -1));//Back
        faces.Add(new Vector3Int(18, 19, 21)); texture_index_list.Add(new Vector3Int(22, 23, 24)); normals.Add(new Vector3(0, 0, -1));//Back
        faces.Add(new Vector3Int(18, 21, 20)); texture_index_list.Add(new Vector3Int(22, 24, 25)); normals.Add(new Vector3(0, 0, -1));//Back
        faces.Add(new Vector3Int(20, 21, 26)); texture_index_list.Add(new Vector3Int(24, 25, 26)); normals.Add(new Vector3(0, 0, -1));//Back
        faces.Add(new Vector3Int(22, 20, 26)); texture_index_list.Add(new Vector3Int(28, 24, 26)); normals.Add(new Vector3(0, 0, -1));//Back
        faces.Add(new Vector3Int(22, 26, 27)); texture_index_list.Add(new Vector3Int(28, 26, 27)); normals.Add(new Vector3(0, 0, -1));//Back
        faces.Add(new Vector3Int(22, 27, 23)); texture_index_list.Add(new Vector3Int(28, 27, 29)); normals.Add(new Vector3(0, 0, -1));//Back
        faces.Add(new Vector3Int(22, 23, 25)); texture_index_list.Add(new Vector3Int(31, 30, 29)); normals.Add(new Vector3(0, 0, -1));//Back
        faces.Add(new Vector3Int(22, 25, 24)); texture_index_list.Add(new Vector3Int(29, 30, 27)); normals.Add(new Vector3(0, 0, -1));//Back
        faces.Add(new Vector3Int(8, 22, 24)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(-1, 0, 0));//Insides
        faces.Add(new Vector3Int(8, 24, 10)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(-1, 0, 0));//Insides
        faces.Add(new Vector3Int(7, 12, 26)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(-1, 0, 0));//Insides
        faces.Add(new Vector3Int(7, 26, 21)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(-1, 0, 0));//Insides
        faces.Add(new Vector3Int(5, 7, 21)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(-1, 0, 0));//Insides
        faces.Add(new Vector3Int(5, 21, 19)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(-1, 0, 0));//Insides
        faces.Add(new Vector3Int(2, 3, 17)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(-1, 0, 0));//Insides
        faces.Add(new Vector3Int(2, 17, 16)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(-1, 0, 0));//Insides
        faces.Add(new Vector3Int(12, 13, 27)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(0, -1, 0));//Bottom
        faces.Add(new Vector3Int(12, 27, 26)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(0, -1, 0));//Bottom
        faces.Add(new Vector3Int(1, 15, 18)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(0, -1, 0));//Bottom
        faces.Add(new Vector3Int(1, 18, 4)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(0, -1, 0));//Bottom
        faces.Add(new Vector3Int(3, 5, 19)); texture_index_list.Add(new Vector3Int(17, 14, 15)); normals.Add(new Vector3(0, -1, 0));//Bottom
        faces.Add(new Vector3Int(3, 19, 17)); texture_index_list.Add(new Vector3Int(17, 15, 16)); normals.Add(new Vector3(0, -1, 0));//Bottom
    }

    public GameObject CreateUnityGameObject()
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();

        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();
        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();

        List<Vector3> coords = new List<Vector3>();
        List<int> dummy_indices = new List<int>();
        List<Vector2> text_coords = new List<Vector2>();
        List<Vector3> normalz = new List<Vector3>();

        for (int i = 0; i < faces.Count; i++)
        {
            Vector3 normal_for_face = normals[i];

            normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3);  text_coords.Add(texturecoordinates[texture_index_list[i].x]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 2); text_coords.Add(texturecoordinates[texture_index_list[i].y]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 1); text_coords.Add(texturecoordinates[texture_index_list[i].z]); normalz.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummy_indices.ToArray();
        mesh.uv = text_coords.ToArray();
        mesh.normals = normalz.ToArray();
        mesh_filter.mesh = mesh;

        return newGO;
    }
}
