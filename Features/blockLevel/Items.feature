Feature: Item management
  In order to use and share items in the system
  As the donator
  I want to be able to manage items in the system

  Scenario Outline: Publish an item to donate
  Given I am logged in the system
   When I try to add a new available item
    And I categorize it properly
    And I share my location
  Then A new item is available to be donate for this location
  Examples:
  | Name | Category | Location | Amount |
  | Some T-Shirt  | My location (some coordinate) | Clothes  | 1  |
  | Rice  | Food | My location (some coordinate) | 5  |
