Feature: Support multi languages on the system
  In order to have the possibility to switch languages on he system
  As any user
  I want to be able to manage languages on the system

  Scenario: First time opening the system
  Given That is the first time I have entered on the system
  When The page opens
  Then The site or app is open with default language pre configured on the system

  Scenario: Saving preferences
  Given I switched the system language and closed the page or app
  When I open the site or app again
  Then the system shall use the last language preference selected by the user

