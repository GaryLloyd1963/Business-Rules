# Business Rules
When you go in to meet the existing order entry folks, you discover that their business practices border on chaotic: no two product lines have the same set of processing rules. To make it worse, most of the rules aren’t written down: you’re often told something like “oh, Carol on the second floor handles that kind of order.”

During first day of meetings, you’ve decided to focus on payments, and in particular on the processing required when a payment was received by the company. You come home, exhausted, with a legal pad full of rule snippets such as:

- If the payment is for a physical product, generate a packing slip for shipping.
- If the payment is for a book, create a duplicate packing slip for the royalty department.
- If the payment is for a membership, activate that membership.
- If the payment is an upgrade to a membership, apply the upgrade.
- If the payment is for a membership or upgrade, e-mail the owner and inform them of the activation/upgrade.
- If the payment is for the video “Learning to Ski,” add a free “First Aid” video to the packing slip (the result of a court decision in 1997).
- If the payment is for a physical product or a book, generate a commission payment to the agent.
and so on, and so on, for seven long, long, yellow pages.

And each day, to your horror, you gather more and more pages of these rules.

Now you’re faced with implementing this system. The rules are complicated, and fairly arbitrary. What’s more, you know that they’re going to change: once the system goes live, all sorts of special cases will come out of the woodwork.

Objectives
How can you tame these wild business rules? How can you build a system that will be flexible enough to handle both the complexity and the need for change? And how can you do it without condemning yourself to years and years of mindless support?

# My Approach
The problem presented here is one where rules can change, and there is complexity in what happens in given situations. So I've focussed on the 'S' in SOLID, single responsibilities - try and keep any inter-dependencies to a minimum, keep classes small and with distinct and clear responsibilities. I've also used 'factories' which make decisions on what objects to create with the appropriate behaviours for the given contexts.

Each payment received will create a series of steps to process it, each step produces one or more actions.

        Payment received->Steps->Actions

This is by no means a full solution, it does not have any database backend code, but should show a good level of flexibility as a concept. Running the console app shows a few example outputs.

# Technologies Used
- C#
- Structuremap dependency injection
- Interfaces
- Unit tests (NUnit 3)
- Acceptance tests (NUnit 3)
