using UnityEngine;
using System.Collections;

public class CatmullRomStEd : MonoBehaviour
{
	public Transform[] controlPoints;
	
	//Play in the editor mode, no need to work in the game mode
	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;

		for (int i = 0; i < controlPoints.Length; i++)
			DisplayCatmullRomSpline(i);
	}

	
	void DisplayCatmullRomSpline(int pos)
	{
		//Here, you need to draw a line (draw a spline) in between 2 points
		//Catmull-Rom algorithm for deriving points: 

		//Create 4 Vector3 points to form a spline between p1 and p2
		//Since our spline is looped, be sure that for end and start points, you 
		//do find proper indices in your range 0..n-1 for your connections, so call 
		//CorrectIndex function if necessary

		//E.g/
		// Vector3 p0 = controlPoints[/*//TODO..whatever index*/].position;
		// Vector3 p1 = //TODO..
		// Vector3 p2 = //TODO..
		// Vector3 p3 = //TODO..		
        Vector3 p0 = controlPoints[CorrectIndex(pos - 1)].position;
        Vector3 p1 = controlPoints[pos].position;
        Vector3 p2 = controlPoints[CorrectIndex(pos + 1)].position;
        Vector3 p3 = controlPoints[CorrectIndex(pos + 2)].position;

		//The start position of our line is p1 and it is defined here
		Vector3 px = p1;

		//How many times should we loop? 5 for our initial case. 
		//TODO..Try different number of control points and different loop numbers here
		for (int i = 1; i <= 5; i++)
		// for (int i = 1; i <= 10; i++)
		// for (int i = 1; i <= 50; i++)
		{
			////TODO..parameter t can be computed as 1/loop number * i
			// float t = //TODO..;
			float t = 1.0f / 5*1;
			Vector3 py = SolveCatmullRom(t, p0, p1, p2, p3);
			Gizmos.DrawLine(px, py);
			px = py;
		}
	}

	//Index control for looping
	int CorrectIndex(int index)
	{
		if (index < 0)
			// index = //TODO..
			index = controlPoints.length-1;
		// else if (index > controlPoints.Length)
		// 	// index = //TODO..;
		// 	index = 0;
		else if (index >= controlPoints.Length)
			index = 0//TODO..;
//???
		return index;
	}

	
	Vector3 SolveCatmullRom(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
		//Decide about the coefficients a, b, c and d
		//one example is:
		//a = 2p1
		//b=p2-p0
		//c=-p3+4p2-5p1+2p0
		//d=p3-3p2+3p2-p0

		Vector3 a = //TO DO:
		Vector3 b = //TO DO:
		Vector3 c = //TO DO:
		Vector3 d = //TO DO:

		
		Vector3 pos = //TO DO: //The cubic polynomial: a + b * t + c * t^2 + d * t^3
		return pos;
	}
}
