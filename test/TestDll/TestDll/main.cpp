#define API(retype) extern "C" __declspec(dllexport) retype __cdecl
#include <iostream>
#include <vector>


typedef struct Pointf
{
	float x;
	float y;
} Pointf;


class KeyPoint
{

public:
	KeyPoint(Pointf pt, float size, float angle = -1, float response = 0, int octave = 0, int class_id = -1);

	Pointf pt;
	float size;
	float angle;
	float response;
	int octave;
	int class_id;
};

KeyPoint::KeyPoint(Pointf pt, float size, float angle, float response, int octave, int class_id)
{
	this->pt = pt;
	this->size = size;
	this->angle = angle;
	this->response = response;
	this->octave = octave;
	this->class_id = class_id;

}

typedef struct Feature
{
	int index;
	Pointf point;
	std::vector<KeyPoint> points;
	KeyPoint key;
}Feature;

API(void) test(KeyPoint point)
{
	std::cout << "x: " << point.pt.x << " y: " << point.pt.y << std::endl;
	std::cout << "size: " << point.size << std::endl;
	std::cout << "angle: " << point.angle << std::endl;
	std::cout << "response: " << point.response << std::endl;
	std::cout << "octave: " << point.octave << std::endl;
	std::cout << "class_id: " << point.class_id << std::endl;
}

API(void) to_delete(void* obj)
{
	delete obj;
}

API(KeyPoint*) get_ptr(std::vector<KeyPoint>* points)
{
	return &(points->at(0));
}

API(size_t) get_size(std::vector<KeyPoint>* points)
{
	return points->size();
}

API(std::vector<KeyPoint>*) create_ptr(KeyPoint* data, size_t dataLength)
{
	return new std::vector<KeyPoint>(data, data + dataLength);
}

API(void) test3(std::vector<KeyPoint>* points)
{
	for (auto& point : *points)
	{
		std::cout << "x: " << point.pt.x << " y: " << point.pt.y << std::endl;
		std::cout << "size: " << point.size << std::endl;
		std::cout << "angle: " << point.angle << std::endl;
		std::cout << "response: " << point.response << std::endl;
		std::cout << "octave: " << point.octave << std::endl;
		std::cout << "class_id: " << point.class_id << std::endl;
	}
}




API(void) test2(Feature** ptr)
{
	auto keys = new std::vector<KeyPoint>();
	auto kp = new KeyPoint({ 0,0 }, 0);
	auto feature = new Feature(0, { 0, 0 }, *keys, *kp);

	feature->index = 1;
	feature->point.x = 1.0;
	feature->point.y = 2.0;

	std::vector<KeyPoint> points;

	for (int i = 0; i < 10; i++)
	{
		auto v = static_cast<float>(i);
		points.push_back(KeyPoint({ v,v }, v, v, v, i, i));
	}
	feature->points = points;
	feature->key = KeyPoint({ 1.0, 2.0 }, 1.0, 1.0, 1.0, 1, 1);

	ptr = &feature;
}