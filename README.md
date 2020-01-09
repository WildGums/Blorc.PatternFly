# Blorc.PatternFly

Blazor wrappers for [PatternFly](https://www.patternfly.org/).

To view the latest *develop* branch in action, visit the GitHub pages: http://blorc-patternfly.wildgums.com/

The ultimate goal of this library is to wrap all PatternFly components and making them available as Blazor components.

![](design/image.png)

## Components

### Done

- About modal
- Accordion
- Alert
- Application launcher
- Avatar
- Background image
- Badge
- Brand
- Breadcrumb
- Button
- Card
- Checkbox
- Chip group
- Clipboard copy
- Dropdown
- Empty state
- Expandable
- FormSelect
- Input group
- Label
- List
- Modal
- Nav
- Page
- Progress
- Radio
- Select
- Table
- Tabs
- Text
- Text area
- Text input
- Title
- Tooltip

### Todo

- Context selector
- Data list
- Form
- Login page
- Options menu
- Pagination
- Popover
- Skip to content
- Switch
- Wizard

## Layouts

### Done

- Bullseyes
- Flex
- Gallery
- Grid
- Level
- Split
- Stack

### Todo

- Toolbar

## Examples

http://blorc-patternfly.wildgums.com/

## Contributing

If you would like support for any new component, you can get in touch by:

- Creating tickets.
- Contributing by pull requests.
- Contributing via Open Collective.

### How to update Patternfly assets?

- Install patternfly from npm repository in an external folder

    `npm install @patternfly --save`

- Update the following files and folders in `Blorc.PatternFly\wwwroot\patternfly\` with the files and folders in  `react\node_modules\@patternfly\patternfly\` 
    - patternfly.css 
    - assets