Feature: Authentication Feature

  In order to be able to use the system
  As the User
  I want to log in the system through different platforms

  Scenario: Sign up through e-mail
  Given I have a valid e-mail
  When I try to sign up the system
    And confirm my e-mail
  Then I can access the system

  Scenario Outline: Sign up through Social platform
  Given I have an account on a social platform <social_network>
  When I try to sign up the system using one social platform
    And I give access on target platform
  Then I can access the system
  Examples:
  | social_network  |
  | Facebook        |
  | Twitter         |
  | Instagram       |
  | Google          |

  Scenario: Try to sign up same user through different social platform
  Given I already signed up on the system on a different social platform
  When I try to sign up the system
    And I give access on target platform
  Then I register also this platform as a possible access
    And I log in the system instead of sign up again

  Scenario: Try to sign up with an existent e-mail already registered
  Given I already have an account for target e-mail
  When I try to sign up the system
  Then an error message is showed informing that this e-mail is already being used
    And a logging error is triggered with the error details
    And I do not sign up current user

  Scenario: Try to sign up with an invalid e-mail
  Given I have an invalid e-mail
  When I try to sign up the system
  Then an error message is showed informing that this is an invalid e-mail
    And a logging error is triggered with the error details
    And I do not sign up current user

  Scenario: Try to sign up with a valid e-mail, but without confirmation
  Given I have a valid e-mail
  When I try to sign up the system
    And I do not confirm my e-mail
    And I try to acces the system
  Then an error message is showed informing that this account is not verified
    And a logging error is triggered with the error details
    And I do not sign up current user