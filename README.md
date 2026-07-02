# Source:

http://iamnotmyself.com/2011/02/14/refactor-this-the-gilded-rose-kata/

## Objective

Refactor the code following the guidelines set in the next section.
There are no limits or constraints regarding the refactored finished code whatsoever.
The only limitation is that the code must behave as it already does, prior any refactoring.

## Problem Description:

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a
prominent city ran by a friendly innkeeper named Allison. We also buy and sell only the finest goods.
Unfortunately, our goods are constantly degrading in quality as they approach their sell by date. We
have a system in place that updates our inventory for us. It was developed by a no-nonsense type named
Leeroy, who has moved on to new adventures. Your task is to add the new feature to our system so that
we can begin selling a new category of items. First an introduction to our system:

	- All items have a SellIn value which denotes the number of days we have to sell the item
	- All items have a Quality value which denotes how valuable the item is
	- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

	- Once the sell by date has passed, Quality degrades twice as fast
	- The Quality of an item is never negative
	- "Aged Brie" actually increases in Quality the older it gets
	- The Quality of an item is never more than 50
	- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
	- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
	Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
	Quality drops to 0 after the concert

We have recently signed a supplier of conjured items. This requires an update to our system:

	- "Conjured" items degrade in Quality twice as fast as normal items

Feel free to make any changes to the UpdateQuality method and add any new code as long as everything
still works correctly. However, do not alter the Item class or Items property as those belong to the
goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code
ownership (you can make the UpdateQuality method and Items property static if you like, we'll cover
for you).

Just for clarification, an item can never have its Quality increase above 50, however "Sulfuras" is a
legendary item and as such its Quality is 80 and it never alters.

## Other's Solutions:
Emily Bache's:
https://github.com/emilybache/GildedRose-Refactoring-Kata

## NOTE: look out for branches in this repo to checkout solutions for this



# Gilded Rose Refactoring - Hexagonal Architecture with Strategy & Builder Patterns

This project is a decoupled, highly maintainable refactor of the famous **Gilded Rose Refactoring Kata**. 
It is built using **Hexagonal Architecture** principles in **.NET Core 3.1 (C# 8.0)**, enforcing strict 
domain immutability and leveraging design patterns to eliminate deep conditional 
structures (`if-else` / `switch` branchings).

---

## Architecture Blueprint

In Hexagonal Architecture (Ports and Adapters), the core business logic (Domain) is isolated from 
infrastructure, frameworks, and UI adapters. 

* **Domain Core (`GildedRose.Domain`)**: Holds our business rules, entities (`Item`), state orchestrators (`GildedRoseProcessor`), and update criteria (`IItemUpdateStrategy`). It knows nothing about databases, memory storage, or consoles.
* **Infrastructure (`GildedRose.Infrastructure`)**: Implements outbound ports (e.g., `InMemoryItemRepository`).
* **User Interface / Driving Adapters (`GildedRose.Console`)**: The entry point (`Program.cs`) that triggers the business process.

---

## Immutability & The Builder Pattern

To guarantee thread safety, architectural purity, and to avoid side effects across transactions, the `Item` 
entity has been made **completely immutable**. 

Since `.NET Core 3.1` lacks modern `init-only` properties, immutability is achieved using **read-only 
properties (`get;`) and an internal constructor**.

### Why the Builder Pattern?
Because the `Item` properties can only be set via its constructor, instantiating complex or test objects 
directly can become cumbersome and error-prone. The `ItemBuilder` solves this by encapsulating construction 
logic, validating input data, and preventing invalid states from reaching the Domain Core.

```csharp
// Fluent and readable creation inside Infrastructure/Tests
Item item = new ItemBuilder()
    .WithName("Backstage passes to a TAFKAL80ETC concert")
    .WithSellIn(15)
    .WithQuality(20)
    .Build();
```

### Why the Builder Pattern?
The original legacy code evaluated business rules using sequential, high-maintenance conditional filters 
inside `Program.cs`. We replaced this with the Strategy Pattern to follow the Open/Closed Principle (SOLID):
Software components should be open for extension, but closed for modification.

Purpose
*Encapsulate distinct update algorithms for each item type (normal items, Aged Brie, Backstage passes, Sulfuras, etc.).
*Make it easy to add or change update rules without modifying a large switch/case or conditional block.
How it's used here
*Define an interface or abstract contract like IUpdateStrategy with a single method Update(Item item).
*Implement one concrete strategy per item behavior (e.g., NormalItemStrategy, AgedBrieStrategy, BackstagePassStrategy, LegendaryStrategy).
*At runtime, the application chooses the appropriate strategy for each Item (via a registry, factory, or mapping) and invokes Update.

Benefits in this project
*Replaces fragile conditionals with small, focused classes.
*Improves testability: each update rule can be unit-tested independently.
*Simplifies adding new item types: add a new strategy class and register it.