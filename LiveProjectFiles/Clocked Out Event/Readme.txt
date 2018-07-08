Product Backlog Item 140: In addition to displaying all worktime events from today on the login page, also display all worktime events that have no end

Description: After a user inputs a correct username and password, the current days clock-in and clock-out events are displayed. However, if a user is still clocked in from a previous day, that and only that unfinished event should be displayed.

There is an Ajax call that will bring up, after a user successfully inputs a valid username and password, but before hitting one of the submit buttons, that brought up a list of the days current clocks in and outs. However, if the user was still clocked in from a previous day, it would not display anything. So I made a change to the ViewModel logic that will display a users last clock-in event, as well as what day it was from, so they know they are still clocked in from that day.
