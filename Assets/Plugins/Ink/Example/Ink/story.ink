//misc
VAR knockCount = 0

//good acts
VAR knock = false
//this works {knock:foo|bar}

//bad acts

->Start
== Start ==
The full moon lights your way through the forbidding forest toward the witch's hut.  The mayor blamed her for causing the drought last year.  After the second villager died of hunger most of the other villagers got together and drove her out of town.  So now she lived deep in the forest.  Deep enough that few were brave enough to risk the trip for fear of the wolves who also lived in the forest.

You wouldn't be making the trip now if your father was not so ill.  He'd been too ill to work the farm for three weeks.  You'd tried your best to do his work as well as your own, but the bitter truth was you were still too young to do an adult's work, much less two.  If your father didn't get well soon planting season would be over and there wasn't nearly enough planted to see you through next winter.  Without his help, you and all your siblings would starve.  The witch had healed the miller four years ago when the grind stone slipped loose and crushed his leg.  Everyone had said he'd never walk again but the witch cured him.  Maybe she could cure your father too.

In the bright light of the full moon, the witch's hut looks more rickity than terrifying.  From the outside it looks like little more than a pile of sticks braced between two tall trees. A small curl of smoke can be seen rising from one corner.  Since you don't see any flames, it is probably from the witch's fireplace.  She must be home or only recently left. The door to the hut is closed.

+ [Knock politely on the door] -> Knock
+ [Open the door] -> Open_Door
+ [ aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvdsafdsadfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj ] -> Open_Door

== Knock ==
~ knock = true
~ knockCount++
You knock on the door and it creaks open a tiny bit before swinging shut again.
You hear nothing from inside the hut.
You wait for a bit, but nodody answers the door.

{knockCount >=3 : You hear a noise behind you and turn around.  It's the witch! She shuffles tiredly towards you; burdened by a bucket of water.}
{knockCount >=3 : -> Witch_Arrives}
+ [Knock politely on the door again] -> Knock
+ [Open the door] -> Open_Door

== Open_Door ==
//todo
{knock:foo|bar}

->TBD

== Witch_Arrives ==
//todo
->TBD

== TBD ==
+[The rest of this branch is still under development. In the meantime, please try out some of the other choices you can make.]-> END
