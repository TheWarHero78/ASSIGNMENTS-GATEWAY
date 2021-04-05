import { Lion } from './lion';

describe('Lion', () => {
  it('should create an instance', () => {
    expect(new Lion()).toBeTruthy();
  });
    describe(" Lion Testing Lion with fake getRoar() method", function () {
      it('calls the fake getRoar() method created by createSpy()', function () {
        var l = new Lion();
        l.getRoar = jasmine.createSpy();
        l.getRoar();
        expect(l.getRoar).toHaveBeenCalled();
      });
    });

    describe("Lion Testing Lion with fake getRoar() method", function () {
      it('calls the fake getRoar() created by createSpy() with return value', function () {
        var l = new Lion();
        l.getRoar = jasmine.createSpy().and.returnValue('Meow !!!!');
        console.log(l.getRoar());
        expect(l.getRoar()).toEqual('Meow !!!!');
      });
    });

});
