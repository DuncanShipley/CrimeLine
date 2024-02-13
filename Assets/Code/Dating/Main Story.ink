

Macedonia, 2023
Komercijalna Banka
-> Bank
== Bank ==
You: Hey mister! You got some time to spare?
Guard: No
*[Nag him] -> Nag
*[Elude to more] -> Elude
== Nag ==
You: Oh come on don’t be that way
Guard: Excuse me if you aren’t here for anything I'm gonna have to ask you to leave.
*[Nag him] -> Nag
*[Elude to more] -> Elude
*[Question authority] -> Question
->END
==Elude==
You: I have something cool to show you
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
You: Oh hello there, I feel reassured knowing that a capable looking man such as yourself has come to my rescue. I assume you must be the manager because I can’t imagine you having a position any lower. 
Manager: Well you got that right, I'm the manager, what can I do for ya?
//*[]
//*[]
->END
==GITEMS==
You: Excuse me, are you the manager?
Manager: I am
You: Well I've been mistreated by this FINE employee of yours. He’s patronized me and infringed upon my rights as a customer. 
Manager: Is what I'm hearing true?
Guard: Boss listen, I swear on my life I just told them they can’t be loitering here if they’re not here for the bank.
*[Gaslight]-> Gaslight
*[Flirt]-> Flirt
==Gaslight==
You: As I recall, you had refused me service because I just wanted to make small conversation. My original intentions were never to loiter.
Manager: hi lorum ispm
->END
==Flirt==
How do you want to flirt?
*[Compliment intelligence]->ComplimentIntelligence
*[Instill confidence]->InstillConfidence
*[Compliment appearance]->ComplimentAppearance
->END
==ComplimentIntelligence==
->END
==InstillConfidence==
->END
==ComplimentAppearance==
->END

INCLUDE Code.ink