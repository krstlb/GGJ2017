using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour {
	private const float InitScale = 0.02f;
	private float _currentScale = InitScale;
	public const float TargetScale = 3f;
	private const int FramesCount = 1000;
	private const float AnimationTimeSeconds = 10;
	private float _deltaTime = AnimationTimeSeconds/FramesCount;
	private float _dx = (TargetScale - InitScale)/FramesCount;

	private IEnumerator GrowScale() {
		while (true) {
			_currentScale += _dx;
			gameObject.transform.localScale = Vector3.one * _currentScale;
			yield return new WaitForSeconds (_deltaTime);
		}
	}

	private void Awake() {
		StartCoroutine (GrowScale ());
	}
}
