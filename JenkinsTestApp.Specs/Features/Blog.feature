Feature: Blog
	In order for other people to see what I've written
	As a casual blogger
	I would like to have the posibility to display a blog entry

Scenario: Open blog entry
	When I navigate to the webpage corresponding to the blog with the name Foo
	Then I can see a web page whose title is Foo
