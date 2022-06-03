using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
	public CinemachineVirtualCamera VirtualCamera;
	private CinemachineBasicMultiChannelPerlin noise;

	private void Start()
	{
		noise = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
	}

	public void CameraShake(bool active)
	{
		if (active)
			noise.m_AmplitudeGain = 5;
		else
			noise.m_AmplitudeGain = 0;
	}
}
