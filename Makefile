all: clean
	cd binding/ && make

clean:
	cd binding/ && make clean