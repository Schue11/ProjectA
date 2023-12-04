using Godot;
using System;

public partial class ProjectA: Node3D
{
	MeshInstance3D anchor;
	MeshInstance3D ball;
	SpringModel spring;

	double xA, yA, zA;
	float length0;
	float length;
	double angle;
	double angleInit;
	double time;

	Vector3 endA;
	Vector3 endB;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello MEE 381 in Godot");
		xA = 0.0; yA = 1.2; zA = 0.0;
		anchor = GetNode<MeshInstance3D>("Anchor");
		ball = GetNode<MeshInstance3D>("Ball1");
		spring = GetNode<SpringModel>("SpringModel");
		endA = new Vector3((float)xA, (float)yA, (float)zA);
		anchor.Position = endA;

		pend = new SimPendulim();

		length0 = length = 0.9f;
		spring.GenMesh(0.05f, 0.015f, length, 6.0f, 62);
	
		angleInit = Mathf.DegToRad(60.0);
		float angleF = (float)angleInit;
		pend.Angle = (double)angleInit;

		endB.X = endA.X + length*Mathf.Sin(angleF);
		endB.Y = endA.Y - length*Mathf.Cos(angleF);
		endB.Z = endA.Z;
		PlacePendulum(endB);

		time = 0.0;

	}

    public override void _Process(double delta)
    {
    //   float angleF = (float)Math.Sin(3.0 * time);
	//   float angleA = (float)(0.4*time);
	//   length = length0 + 0.3f * (float)Math.Cos(4.0*time);
	float angleA = 0.0f;
	
	pend.StepRK2(time, delta);
	float angleF = (float)pend.Angle;
	float hz = length*Mathf.Sin(angleF);

	  endB.X = endA.X + hz*Mathf.Cos(angleA);
	  endB.Y = endA.Y - length*Mathf.Cos(angleF);
	  endB.Z = endA.Z + hz*Mathf.Sin(angleA);
	  PlacePendulum(endB); 
	  time += delta;

    }

	private void PlacePendulum(Vector3 endBB)
	{
		spring.PlaceEndPoints(endA,endB);
		ball.Position = endBB;
	}

}
