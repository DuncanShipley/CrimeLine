EXTERNAL SetCharacter(CurrentSpeaker)
EXTERNAL ChangeEmotion(CurrentEmotion)

Skopje Macedonia, 2023 <br>Komercijalna Bank
-> Bank

== Bank ==
~ SetCharacter("guard")
You: Hey mister! You got some time to spare?
Guard: No
*[Nag him] -> Nag
*[Elude to more] -> Elude

== Nag ==
~ChangeEmotion("annoyed")
You: Oh come on, not even 5 minutes? Theres other gaurds here, nothing is going to happen.
Guard: Excuse me if you aren’t here for buisness, I'm gonna have to ask you to leave.
*[Nag him] -> Nag2
*[Elude to more] -> Elude
*[Question authority] -> Question
->END

==Nag2==
You: You can even answer my questions?
Guard: No Im working. I'm going to ask you again to leave the premise. 
You: Pleaseeeee, its just a few questions. I'm from out of town. I just want to know if there is anywhere specific I should visit.
->END

==Elude==
You: I have something cool to show you.
Guard: I'm not going to follow, please leave.
->END

==Question==
You: Is this how you normally treat patrons of this establishment? If so I must inform
*[The general public] ->Public
*[The management] ->Management

==Public==
the general public of the poor treatment of us customers
Guard: Please step outside.
*[Threaten] ->ThreatenP
*[Seek Pity]->END

==Management==
the management of the poor treatment of us customers
Guard: Hey listen we don’t have to go there, i’m sorry if I offended you, i’m just doin my job here.
*[Threaten Management] ->ThreatenM

==ThreatenP==
You: Then I'll be taking this issue up with the general public.
->END

==ThreatenM==
You: Then I’ll be taking this issue up with Management. 
You: Excuse me! May I speak to the Manager of this establishment?
Manager: What’s the issue here?
*[Flirt] -> IntroFlirt
*[Give it to em straight] -> GITEMS

==IntroFlirt==
You: Oh hello there, I feel reassured knowing that a capable looking man such as yourself has come to my rescue. <br>I assume you must be the manager because I can’t imagine you having a position any lower. 
Manager: Well you got that right, I'm the manager, what can I do for ya?
//*[]
//*[]
->END

==GITEMS==
You: Excuse me, are you the manager?
Manager: I am
You: Well I've been mistreated by this employee of yours. He’s patronized me and infringed upon my rights as a customer. 
Manager: Is what I'm hearing true?
Guard: I just told them they cant be loitering on bank grounds.
*[Gaslight]-> Gaslight
*[Flirt]-> Flirt

==Gaslight==
You: As I recall, you refused me service because I just wanted to have a conversation and admire this beautiful building.<br>My original intentions were never to loiter.
Manager: You can admire the building, but please dont distract my workers.
You: Im sorry, I was just trying to ask some questions. Im from out of town.<br>I was wondering what places I should visit. Your gaurd told me to leave before I could even ask.
->END

==Flirt==
How do you want to flirt?
*[Compliment intelligence]->ComplimentIntelligence
*[Instill confidence]->InstillConfidence
*[Compliment appearance]->ComplimentAppearance
->END

==ComplimentIntelligence==
lorum ispm
->END

==InstillConfidence==
lorum ispm
->END

==ComplimentAppearance==
You: You look quite handsome today mister
Manager: Thank you, you too look very nice 
->END
