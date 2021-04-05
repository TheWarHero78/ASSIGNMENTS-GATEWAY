import { Human } from './human';

describe('Human', () => {
  it('should create an instance', () => {
    expect(new Human()).toBeTruthy();
  });

  describe("Multiple spies created with createSpyObj()", function() {
  	var Human;

  	beforeEach(function() {
    	Human = jasmine.createSpyObj('Human', ['eat', 'sleep', 'code']);
  	});

    it('should create multiple spy methods', function() {
        expect(Human.eat).toBeDefined();
        expect(Human.sleep).toBeDefined();
        expect(Human.code).toBeDefined();
    });
});

describe("Multiple spies created with createSpyObj()", function() {
  var Human;

  beforeEach(function() {
    Human = jasmine.createSpyObj('Human', ['eat', 'sleep', 'code']);
    Human.eat('paneer tikka');
    Human.sleep(8)
    Human.code('angular');
  });

  it('should track the invoked spy methods', function() {
      expect(Human.eat).toHaveBeenCalled();
      expect(Human.sleep).toHaveBeenCalled();
      expect(Human.code).toHaveBeenCalled();
  });
});



});
