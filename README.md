## WarpKez.ScaleModelling

### A Collection of mathematical classes and models primarily used in scale modelling.

### Overview of classes

- Fractions
- Metric Conversion
- Scale Conversion
- Trigonometry

### Fractions Class

Methods and models for performing mathematical functions on fractions such as
- addition and subtration,
- multipication and division,
- finding the lowest common denominator,
- provide fraction sanititation,
- and simplify fractions.

### Metric Class

Methods and models for performing conversion between metric systems specifically imperial and metric measurements relating to distance
- Converting yard to feet, then to inches,
- Converting imperial to metric,
- Determinging the closest inch, above and below the given to 1/64th precision. (*I am flat out seeing 1/32"*) 

### Scale Class

Methods and models for performing conversions between scales and generating tables
- Converting from real world measurements to scale world imperial and metric,
- Generating conversion tables across common scales,
- Creating 'near enough' measurements for inches to within 1/64" precision.
- Create plot points for curves.

### Trigonometry Class

Methods and models related to triangles
- SIN, COS, TAN, 1/SIN, 1/COS, 1/TAN,
- How to find the length of each side from an angle and its companion side,

### Caveats

- An integer overflow is possible, when calculating the nearest/good enough inch values, this is because the code will convert the decimal/double to a
fraction (numerator / denominator).  To prevent this, a limit of 5 decimal places is used, and the base denominator is set to 10^5 or 100,000.
- An integer overflow can occur when using negative fractions.  This mostly occurs when searching for the lowest common denominator but can be quite random.
To combat this, the fraction is first sanitised (made positive) then the operation is performed, and the process is reversed and the negative sign re-applied.
