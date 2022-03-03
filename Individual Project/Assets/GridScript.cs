using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GridScript : Graphic
{
    public int rows;
    public int columns;

    float width;
    float height;

    float widthOfLine = (float)2;

    float totalWidth;
    float totalHeight;

    public TextMeshProUGUI rowText;
    public TextMeshProUGUI columnText;

    private void Update()
    {
        rows = Int32.Parse(rowText.text);
        columns = Int32.Parse(columnText.text);
        SetVerticesDirty();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        //rows = Int32.Parse(rowText.text);
        //print(Int32.Parse(rowText.text));

        //rows = Int32.Parse(theSlider.value.ToString());

        vh.Clear();

        totalWidth = rectTransform.rect.width;
        totalHeight = rectTransform.rect.height;

        width = totalWidth / (float)columns;
        height = totalHeight / (float)rows;

        int counter = 0;

        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                createSquare(i, j, counter, vh);
                counter++;
            }
        }

    }

    void createSquare(int x, int y, int counter, VertexHelper vh)
    {
        float xPos = (width * x) - (int)(totalWidth / 2);
        float yPos = (height * y) - (int)(totalHeight / 2);

        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        //Left Side
        vertex.position = new Vector3(xPos, yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos, yPos + height);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + widthOfLine, yPos + height);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + widthOfLine, yPos);
        vh.AddVert(vertex);

        //Top Side
        vertex.position = new Vector3(xPos, yPos + height);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + width, yPos + height);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + width, yPos + (height - widthOfLine));
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos, yPos + (height - widthOfLine));
        vh.AddVert(vertex);

        //Right Side
        vertex.position = new Vector3(xPos + width, yPos + height);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + width, yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + (width - widthOfLine), yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + (width - widthOfLine), yPos + height);
        vh.AddVert(vertex);

        //Bottom Side
        vertex.position = new Vector3(xPos + width, yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos, yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos, yPos + widthOfLine);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + width, yPos + widthOfLine);
        vh.AddVert(vertex);

        int offset = counter * 16;

        //Left Side
        vh.AddTriangle(offset + 0, offset + 1, offset + 2);
        vh.AddTriangle(offset + 2, offset + 3, offset + 0);

        //Top Side
        vh.AddTriangle(offset + 4, offset + 5, offset + 6);
        vh.AddTriangle(offset + 6, offset + 7, offset + 4);

        //Right Side
        vh.AddTriangle(offset + 8, offset + 9, offset + 10);
        vh.AddTriangle(offset + 10, offset + 11, offset + 8);

        //Bottom Side
        vh.AddTriangle(offset + 12, offset + 13, offset + 14);
        vh.AddTriangle(offset + 14, offset + 15, offset + 12);
    }
}
