IDEAS
---------

## Wardrobe Element
- Add size ctor
- Get rid of the default ctor ? (enforce valid init with size)
- Use exception to enforce positives
- Maybe enforce positive number by using a class, instead of an int ?
- Or maybe even better use uint as type (and check for zero ?), as "PositiveInteger" semantically includes zero (and we just don't want 0 for our domain specific problem ...)


## Furniture Dealer
- get rid of the "validate method" (IsWardrobeFittingWall) (no needed at all, or at least not needed to be public)
- what to use as the return type of the Configure Wardrobe ? - maybe sth better than "List of Lists ..." ???
