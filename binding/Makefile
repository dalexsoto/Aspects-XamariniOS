XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=xcode/AspectsStaticLib
PROJECT=$(PROJECT_ROOT)/Aspects.xcodeproj
TARGET=Aspects
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

# 	If you updated the binding to a newer version don't forget to change
#	the Git TAG of newer the version you are binding against
ASPECTSVERSIONTAG=1.3.1

all: Aspects.dll

xcode/Aspects:
	cd xcode && git clone git@github.com:steipete/Aspects.git && cd Aspects && git checkout tags/$(ASPECTSVERSIONTAG)
	cp xcode/Aspects/Aspects.h xcode/AspectsStaticLib/Aspects/
	cp xcode/Aspects/Aspects.m xcode/AspectsStaticLib/Aspects/

libAspects-i386.a: xcode/Aspects
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/libAspects.a $@

libAspects-armv7.a: xcode/Aspects
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/libAspects.a $@

libAspects-armv7s.a: xcode/Aspects
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/libAspects.a $@

libAspects-arm64.a: xcode/Aspects
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/libAspects.a $@

libAspects.a: libAspects-i386.a libAspects-armv7.a libAspects-armv7s.a libAspects-arm64.a
	lipo -create -output $@ $^
	
Aspects.dll: libAspects.a
	-mkdir -p ios
	$(MONOXBUILD) /p:Configuration=Release Aspects.csproj
	cp bin/Release/Aspects.dll Aspects.dll

clean:
	-rm -rf libarclite.linkwith.cs *.a *.dll *.mdb bin/ obj/ *.sln *.userprefs build/ list ios xcode/Aspects/ Resources/ xcode/AspectsStaticLib/build
	-rm -rf xcode/AspectsStaticLib/Aspects/Aspects.h xcode/AspectsStaticLib/Aspects/Aspects.m