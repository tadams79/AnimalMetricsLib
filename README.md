# What is the Animal Metrics Library?
The Animal Metrics Library is a software library that provides a set of tools for calculating various growth metrics for animals. These metrics include growth rate, which can be calculated based on the feed nutrition values of the animal. The library is designed to be easy to use and can be integrated into any software application that requires animal growth metrics.

### Details About The Current Release
In this release, v0.0.1, the basic foundation has been implemented to calculate growth rates based on a variety of factors. As I continue to work on this project, the updates will bring with them, better error processing as well as performance enhancements and more complex formulas so that those who are using this library will continuously have the best results.

### Current Formulas Used
* Initial Weight (IW): The weight of the animal at the start of the period.
* Final Weight (FW): The weight of the animal at the end of the period.
* Duration (D): The time period over which growth is measured.

| Formula Description                      | Formula                                                   |
|------------------------------------------|-----------------------------------------------------------|
| **Basic Growth Rate (BGR)**              | $$BGR = \frac{FW - IW}{D}$$                               |
| **Protein Content Adjustment Factor (PCAF)** | $$PCAF = \frac{\text{Actual Protein Content}}{\text{Required Protein Content}}$$ |
| **Energy Content Adjustment Factor (ECAF)** | $$ECAF = \frac{\text{Actual Energy Content}}{\text{Required Energy Content}}$$ |
| **Vitamin and Mineral Index Adjustment Factor (VMIAF)** | $$VMIAF = \frac{\text{Actual VMI}}{\text{Required VMI}}$$ |
| **Overall Nutrition Adjustment Factor (NAF)** | $$NAF = \frac{PCAF + ECAF + VMIAF}{3}$$               |
| **Adjusted Growth Rate (AGR)**          | $$AGR = BGR \times NAF$$                                    |

### Class Models
 - [Adjustment Factors](#adjustment-factors)
 - [Animal Class Model](#animal-model)
 - [Diet Plan](#diet-plan)
 - [Feed Type](#feed-type)
 - [Growth Record](#growth-record)
 - [Nutrition Info](#nutrition-info)







#### Adjustment Factors

#### Animal Model
This model represent an animal with the following properties:
- Initial Weight
- Final Weight
- Duration In Days

#### Diet Plan
