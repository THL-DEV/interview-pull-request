/* Test scenario:
Given user is in the rental-edit page,
When he changes the hour of drop off date to after hours.
Then he will see the alert of `This branch is closed on from XXX to YYY`.

Background: The drop off hour from the selected test data is random. eg: it can be 1pm or 2pm. 
By default, the beginning of after hours is 5pm. So if the drop off hour is 1pm, 
the user needs to click the toggle 5 times, change it into 6pm to trigger the alert above.

Can you please review the changes below?
*/

//click the date field
cy.get(".sc-fzqAb").find("input").click();
//and toggle the time select
cy.get(".sc-fzqAb").find(".rdtTimeToggle").click();
//So we can start a-clickin'
cy.get(".rdtCounters")
  .find(".rdtCounter")
  .eq(0)
  .then((counter) => {
    cy.wrap(counter).find(".rdtBtn").first().click(); //Toggle hour to after hours

    for (let i = 0; i < 5; i++) {
      cy.get(BookingDetailsPage.div_alert).then((alert) => {
        if (
          alert
            .text()
            .includes("This branch is closed")
        ) {
          cy.get(alert).click();
          return true;
        } else {
          cy.wrap(counter).find(".rdtBtn").first().click();
        }
      });
    }
  });
