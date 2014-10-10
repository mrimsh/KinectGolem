using UnityEngine;
using System.Collections;
using Kinect;

public class GolemController : MonoBehaviour {

	public SkeletonWrapper sw;
	public int player;
	public Transform neck;
	private Vector3 neckBasePosition;
	private Quaternion neckBaseRotation;

	// Use this for initialization
	void Start () {
		neckBasePosition = neck.position;
		neckBaseRotation = neck.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (sw.pollSkeleton ()) {
			Vector3 playerNeckDirection = sw.bonePos[player, (int) NuiSkeletonPositionIndex.Head] - sw.bonePos[player, (int) NuiSkeletonPositionIndex.ShoulderCenter];
			Debug.Log("neckBaseRotation: " + neckBaseRotation.eulerAngles + "; AbsoluteOrientation: " + 
			          sw.boneAbsoluteOrientation[player, (int) NuiSkeletonPositionIndex.Head].eulerAngles + "; neckBaseRotation: " + 
			          sw.boneLocalOrientation[player, (int) NuiSkeletonPositionIndex.Head].eulerAngles);
			neck.rotation = Quaternion.Euler (sw.boneAbsoluteOrientation[player, (int) NuiSkeletonPositionIndex.Head].eulerAngles + neckBaseRotation.eulerAngles + new Vector3(0f, 180f, 0f));
		} 
	}
}

