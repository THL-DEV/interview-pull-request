/* Test scenario:
Given user is the rental-edit page,
When he change the hour of drop off date to after hours.
Then he will see the alert of branch is closed at during after hours.

Candition: The original hour is not fixed. eg: it can be 1pm or 2pm. the begin of after hours is 5pm. So if the original is 1pm, 
then user needs to click the toggle 5 times, to let the time become 6pm to trigger the alert.

Can you find out what are the issues in the code below? and how to fix or refactor them?
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
            .includes("The time selected is outside the branch operating hours")
        ) {
          cy.get(alert).click();
          return true;
        } else {
          cy.wrap(counter).find(".rdtBtn").first().click();
        }
      });
    }
  });
