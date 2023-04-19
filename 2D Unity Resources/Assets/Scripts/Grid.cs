using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class Grid {
    public const int sortingOrderDefault = 5000;
    private int width;
    private int height;
    private int[,]  gridArray;
    private TextMesh[,] debugTextArray;
    private float cellSize;
    private Vector3 Origin;
    public Grid(int width, int height,float cellSize , Vector3 Origin){
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        
        debugTextArray = new TextMesh[width,height];
        gridArray = new int[width,height];   
        for(int i=0;i<gridArray.GetLength(0);i++){
            for(int j=0;j<gridArray.GetLength(1);j++){
                debugTextArray[i,j] = UtilsClass.CreateWorldText(gridArray[i,j].ToString(), null,GetWorldPosition(i,j) + new Vector3(cellSize,cellSize)*0.5f,20,Color.red,textAnchor:TextAnchor.MiddleCenter,textAlignment:TextAlignment.Center);
                Debug.DrawLine(GetWorldPosition(i,j),GetWorldPosition(i,j+1),Color.white,100f);
                Debug.DrawLine(GetWorldPosition(i,j),GetWorldPosition(i+1,j),Color.white,100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0,height),GetWorldPosition(width,height),Color.white,100f);
        Debug.DrawLine(GetWorldPosition(width,0),GetWorldPosition(width,height),Color.white,100f);
        
        setValue(2,2,67);
    }

    
    private Vector3 GetWorldPosition(int x, int y){
        return new Vector3(x,y) * cellSize + Origin;
    }
    
    private void GetXY(Vector3 WorldPosition,out int x, out int y){
        WorldPosition -= Origin;
        x= Mathf.FloorToInt(WorldPosition.x/cellSize);
        y= Mathf.FloorToInt(WorldPosition.y/cellSize);
    }

    public void setValue(int x,int y, int value){
        if(x>=0 && y>=0 && x<width && y<height){
        gridArray[x,y] = value;
        debugTextArray[x,y].text = gridArray[x,y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value){
        int x,y;
        GetXY(worldPosition,out x,out y);
        setValue(x,y,value);
    }

    public int GetValue(Vector3 pos){
        int x,y;
        GetXY(pos,out x,out y);
        return gridArray[x,y];
    
    }

    public int GetValue(int x, int y){
        if(x>=0 && y>=0 && x<width && y<height){
            return gridArray[x,y];
        }else{
            return -1;
        }
    }
    
}

