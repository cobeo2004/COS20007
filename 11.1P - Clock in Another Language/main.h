#include <iostream>
#include <string>
#include <sstream>
#include <iomanip>
#include <thread>
#include <chrono>

namespace CounterClass
{
    class Counter
    {
    private:
        int _count;
        std::string _name;

    public:
        Counter(const std::string &name) : _name(name), _count(0)
        {
        }

        Counter(const std::string &name, int count) : _name(name), _count(count)
        {
        }

        void Increment();
        void Reset();
        std::string GetName() const;
        void SetName(std::string value);
        int GetTicks() const;
    };
};

namespace ClockClass
{
    class Clock
    {
    private:
        CounterClass::Counter *_second;
        CounterClass::Counter *_minute;
        CounterClass::Counter *_hour;

    public:
        Clock();
        void Tick();
        void Reset();
        void SetTime();
        std::string GetCurrentTime() const;
        ~Clock();
    };
};
