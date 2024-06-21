
Feature: test

    @smoke
    Scenario: playwright navigation
        Given the user navigates to the playwright page
        And the page is loaded
        When the user clicks get started button
        Then the user should redirect to get started page
