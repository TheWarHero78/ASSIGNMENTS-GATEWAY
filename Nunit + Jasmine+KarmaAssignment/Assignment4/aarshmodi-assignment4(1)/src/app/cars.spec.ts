import { Cars } from './cars';

describe('Cars', () => {
  it('should create an instance', () => {
    expect(new Cars()).toBeTruthy();
  });

  describe('spyOn() Cars. Car', function () {
    it('should be BMW', function () {
      var c = new Cars();
      c.getNextCar();
      expect(c.car).toEqual('BMW');
    });
  });

  describe('spyOn() Cars. Car Using Call Throogh', function () {
    it('should be BMW', function () {
      var c = new Cars();
      spyOn(c, 'nextCar').and.callThrough();
      c.getNextCar();
      expect(c.car).toEqual('BMW');
    });
  });

  describe('spyOn() Cars. Car Using Return Value ', function () {
    it('should be Range Rover', function () {
      var c = new Cars();
      spyOn(c, 'nextCar').and.returnValue('Range Rover');
      c.getNextCar();
      expect(c.getNextCar()).toEqual('Range Rover');
    });
  });

  describe('spyOn() Cars. Car Using Call Fake', function () {
    it('should not be BMW', function () {
      var c = new Cars();
      spyOn(c, 'nextCar').and.callFake(function () {
        console.log('in the future');
        return 'Aarsh';
      });
      c.getNextCar();
      expect(c.nextCar()).not.toEqual('BMW');
    });
  });

  describe('spyOn() Cars. Car Using Call Fake with Params', function () {
    it('should be Aarsh In Range Rover', function () {
      var c = new Cars();
      spyOn(c, 'nextCar').and.callFake(function (person) {
        return person + ' In Range Rover'
      });
      c.getNextCar();
      expect(c.nextCar('Aarsh')).toEqual('Aarsh In Range Rover');
    });
  });

});
