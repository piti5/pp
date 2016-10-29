using UnityEngine;
using System.Collections;

public class EnemyBattleManager : MonoBehaviour {

	private Animator anim;
	private CharacterController controller;
	private bool battle_state;
	public float speed = 0.5f;
	public float runSpeed = 1.7f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;

	private enum EnemyTag
	{
		Ent,//Character
		Frogman,//Monster
		Goblins,//Character
		Golems,//Monster
		iguana,//Monster
		Monster_Rabbit,//Monster
		Ogre,//Character
		Succubus,//Character

	};

	private DistanceSearch dist;

	private AnimatorStateInfo stateInfo;

	// Use this for initialization
	void Start () {
		dist = GetComponent<DistanceSearch> ();
		anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController> ();
		anim.SetInteger ("moving", 1);

	}

	void Update ()
	{
		stateInfo = anim.GetCurrentAnimatorStateInfo(0);

		if (dist.SearchedFlag) {
			anim.SetInteger ("moving", 0);
			anim.SetInteger ("battle", 1);
			battle_state = true;
		} else {
			anim.SetInteger ("battle", 0);
			anim.SetInteger ("moving", 1);
		}

		if (stateInfo.IsName("idle_battle")) {
			anim.SetInteger ("moving", Random.Range(3, 5));
			if (dist.target == null) {
				anim.SetInteger ("battle", 0);
			}
		}

		if (anim.GetInteger ("moving") == 1) {
			if(controller.isGrounded)
			{
				moveDirection=transform.forward * speed * runSpeed;

			}
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;
		}
	}
}
