using Godot;
using System;

public partial class SimBeginScene: Node3D
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
	Vector4 endB;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello MEE 381 in EB221");
		xA = 0.0; yA = 1.2; zA = 0.0;
		anchor = GetNode<MeshInstance3D>("Anchor");
		ball = GetNode<MeshInstance3D>("Ball1");
		spring = GetNode<SpringModel>("SpringModel")
		endA = new Vector3((float)xA, (float)yA, (float)zA);
		anchor.Position = endA;

		pend = new SimPendulum();

		length0 = length = 0.9f;
		spring.GenMesh(0.5f, 0.015f, length, 6.0f, 62);
		
		angleInit = Mathf.DegToRad(60.0);
		float angleF = (float)angleInit;
		pend.Angle = (double)angleInit;

		endB.X = endA.X + length*Mathf.Sin(angleF);
		endB.Y = endA.Y - length*Mathf.Cos(angleF);
		endB.Z = endaA.Z;
		PlacePendulum(endB);

		time = 0.0;

	}

    public override void _Process(double delta)
    {
      float angleA = 0.0f;
	  endB.X = endA.X + length*Mathf.Sin(angleF);
	  endB.Y = endA.Y - length*Mathf.Cos(angleF);
	  PlacePendulum(endB);
	  time += delta;

    }

	private void PlacePendulum(Vector3 endBB)
	{
		spring.PlaceEndPoints(endA,endB);
		ball.Position = endBB
	}

}
