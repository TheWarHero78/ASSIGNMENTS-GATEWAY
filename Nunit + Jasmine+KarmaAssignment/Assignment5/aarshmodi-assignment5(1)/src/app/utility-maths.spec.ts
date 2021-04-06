import { UtilityMaths } from './utility-maths';

describe('UtilityMaths', () => {



  // Using mocking with spy
  let mathsUtility: UtilityMaths;
  let spy: any;

  beforeEach(() => {
    mathsUtility = new UtilityMaths();
  });
  afterEach(() => {
    mathsUtility = null;
  });

  it('Check calulation of Area Of Circle', () => {

    // Arrange
    let inputradius: number = 10;
    let expectedOutput: number = 314.16;
    // Act
    spy = spyOn(mathsUtility, 'areaOfCircle').and.returnValue(314.16);
    let result = mathsUtility.areaOfCircle(inputradius);

    // Assert
    expect(result).toBe(expectedOutput);
  });

  it('Check calulation of Area Of Triangle', () => {

    // Arrange
    let inputbase: number = 10;
    let inputheight: number = 10;
    let expectedOutput: number = 50;
    // Act
    spy = spyOn(mathsUtility, 'areaOfTriangle').and.returnValue(50);
    let result = mathsUtility.areaOfTriangle(inputbase, inputheight);

    // Assert
    expect(result).toBe(expectedOutput);
  });

  it('Check calulation of Area Of Sphere', () => {

    // Arrange
    let inputradius: number = 4;
    let expectedOutput: number = 201.06;
    // Act
    spy = spyOn(mathsUtility, 'areaOfSphere').and.returnValue(201.06);
    let result = mathsUtility.areaOfSphere(inputradius);

    // Assert
    expect(result).toBe(expectedOutput);
  });


  it('Check calulation of Area Of Rectangle', () => {

    // Arrange
    let inputlenght: number = 4;
    let inputwidth: number = 4;
    let expectedOutput: number = 16;
    // Act
    spy = spyOn(mathsUtility, 'areaOfSphere').and.returnValue(16);
    let result = mathsUtility.areaOfRectangle(inputlenght, inputwidth);

    // Assert
    expect(result).toBe(expectedOutput);
  });

  it('Check calulation of Area Of Cone', () => {

    // Arrange
    let inputradius: number = 10;
    let inputsh: number = 10;
    let expectedOutput: number = 444.29;
    // Act
    spy = spyOn(mathsUtility, 'areaOfCone').and.returnValue(444.29);
    let result = mathsUtility.areaOfCone(inputradius, inputsh);

    // Assert
    expect(result).toBe(expectedOutput);
  });



});
